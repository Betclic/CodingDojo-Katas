using System;
using Tcg.Core;

namespace Tcg.Kata.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        private PlayerViewModel _player1;
        private PlayerViewModel _player2;
        public IGame Game { get; set; }

        public PlayerViewModel Player1
        {
            get { return _player1; }
            set
            {
                if (Equals(value, _player1)) return;
                _player1 = value;
                OnPropertyChanged();
            }
        }

        public PlayerViewModel Player2
        {
            get { return _player2; }
            set
            {
                if (Equals(value, _player2)) return;
                _player2 = value;
                OnPropertyChanged();
            }
        }

        public PlayerViewModel ActivePlayerVM { get { return Player1.IsActive ? Player1 : Player2; } }

        public GameViewModel(IGame game, IPlayer p1, IPlayer p2)
        {
            Game = game;
            Player1 = new PlayerViewModel(p1, this);
            Player2 = new PlayerViewModel(p2, this);

            InitHands();
        }

        public void EndOfTurn()
        {
            Game.EndTurn();
            Console.WriteLine("End of turn");
            RaisePropertyChanged("Player1");
            RaisePropertyChanged("Player2");
        }

        private void InitHands()
        {
            Player1.InitHand();
            Player2.InitHand();
        }

        public void BeginOfTurn()
        {
            Game.BeginTurn();
            Console.WriteLine("Begin of turn : " + ActivePlayerVM.Player.Name);
            InitHands();
            RaisePropertyChanged("Player1");
            RaisePropertyChanged("Player2");

            ActivePlayerVM.BeginTurn();

        }

        public void PlayCard(CardViewModel card)
        {
            Game.ActivePlayer.PlayCard(card.Card, Game.OpponentPlayer);
            
            RaisePropertyChanged("Player1");
            RaisePropertyChanged("Player2");
            CheckForWinner();
        }

        public bool Player1Win { get; set; }
        public bool HasWinner { get; set; }

        private void CheckForWinner()
        {
            var winner = Game.GetWinner();
            if (winner != null)
            {
                EndOfTurn();

                HasWinner = true;

                Player1Win = winner == Player1.Player;

                RaisePropertyChanged("Player1Win");
                RaisePropertyChanged("HasWinner");
            }
        }
    }
}