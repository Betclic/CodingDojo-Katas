using System;
using System.Windows.Input;
using Tcg.Kata.ViewModels;

namespace Tcg.Kata
{
    public class EndOfTurnCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        GameViewModel Game { get; set; }
        public PlayerViewModel Player { get; set; }

        public EndOfTurnCommand(GameViewModel game, PlayerViewModel player)
        {
            Game = game;
            Player = player;
        }

        public bool CanExecute(object parameter)
        {
            return Game != null && Player.IsActive;
        }

        public void Execute(object parameter)
        {
            Player.Action = null;
            Game.EndOfTurn();

            Game.BeginOfTurn();
        }
    }
}