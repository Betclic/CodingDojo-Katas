using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Tcg.Core;

namespace Tcg.Kata.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        public IPlayer Player { get; set; }
        public GameViewModel GameVM { get; set; }

        public bool IsAI
        {
            get { return Player.Strategy != null; }
        }

        public string Name { get { return Player.Name; } }

        public int Health
        {
            get { return Player.Health; }
        }

        public int DeckSize { get { return Player.Deck.Count; } }

        public int Mana { get { return Player.Mana; } }
        public int ManaSlots { get { return Player.ManaSlots; } }
        public string ManaString { get { return $"{Mana} / {ManaSlots}"; } }

        public ObservableCollection<int> Slots { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<int> Manas { get; set; } = new ObservableCollection<int>();

        public bool IsActive { get { return GameVM.Game.ActivePlayer == Player; } }

        public ObservableCollection<CardViewModel> HandVM { get; set; }

        public ICommand EndOfTurnCommand { get; set; }

        public PlayerViewModel(IPlayer player, GameViewModel game)
        {
            Player = player;
            GameVM = game;

            EndOfTurnCommand = new EndOfTurnCommand(game, this);

            HandVM = new ObservableCollection<CardViewModel>();
            InitHand();
            InitMana();
        }

        public void InitHand()
        {
            HandVM.Clear();
            Player.Hand.ToList().ForEach(c => HandVM.Add(new CardViewModel(c)));
        }
        public void InitMana()
        {
            Slots.Clear();
            for (int i = 0; i < ManaSlots; i++)
            {
                Slots.Add(i);
            }
            Manas.Clear();
            for (int i = 0; i < Mana; i++)
            {
                Manas.Add(i);
            }

        }

        private CardViewModel _selectedCard;

        public CardViewModel SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                if (value != null && !value.Equals(SelectedCard))
                {
                    Action = null;
                    _selectedCard = value;
                    PlayCard(value);
                }
            }
        }

        public void PlayCard(CardViewModel card)
        {
            if (IsActive)
            {
                GameVM.PlayCard(card);
                Action = card.Action == Core.Action.HEAL ? "+" + card.Value : "-" + card.Value;
                Console.WriteLine(@"'" + Player.Name + @"' played " + card.Action + @" " + card.Value);
            }
            InitHand();
        }

        public async Task PlayCardAsync()
        {
            
            if (IsAI)
            {
                Console.WriteLine("IA thinking");
                var card = await Player.DetermineNextMoveAsync(GameVM.Game.OpponentPlayer);
                if (card != null)
                {
                    var selectedCard = HandVM.ToList().FirstOrDefault(c => c.Card.Equals(card));
                    if (selectedCard != null)
                    {
                        SelectedCard = selectedCard;
                    }
                    //Thread.Sleep(500);
                    await PlayCardAsync();
                }
                 
            }
        }

        private string _action;
        private bool _actionReady;
        private Brush _actionColor;

        public string Action
        {
            get { return _action; }
            set
            {
                if (value == _action) return;
                _action = value;
                OnPropertyChanged();
                ActionReady = _action != null;
                ActionColor = SelectedCard != null && SelectedCard.Action == Core.Action.DAMAGE ? new SolidColorBrush(Colors.DarkRed) : new SolidColorBrush(Colors.DarkGreen);
            }
        }
        public bool ActionReady
        {
            get { return _actionReady; }
            set
            {
                if (value == _actionReady) return;
                _actionReady = value;
                OnPropertyChanged();
            }
        }

        public Brush ActionColor
        {
            get { return _actionColor; }
            set
            {
                if (Equals(value, _actionColor)) return;
                _actionColor = value;
                OnPropertyChanged();
            }
        }

        public async void BeginTurn()
        {
            InitMana();
            Action = null;
            if (IsAI)
            {
                await PlayCardAsync();

                Thread.Sleep(300);
                if (EndOfTurnCommand.CanExecute(null))
                    EndOfTurnCommand.Execute(null);
            }
        }

        public void EndOfTurn()
        {
            Action = null;
        }
    }
}