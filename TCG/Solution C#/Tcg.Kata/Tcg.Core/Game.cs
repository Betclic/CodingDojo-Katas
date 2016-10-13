using System;

namespace Tcg.Core
{
    public class Game : IGame
    {
        public IPlayer ActivePlayer { get; set; }
        public IPlayer OpponentPlayer { get; set; }

        public Game(IPlayer player1, IPlayer player2)
        {
            ActivePlayer = player1;
            OpponentPlayer = player2;
        }

        public void BeginTurn()
        {
            //throw new NotImplementedException();
        }

        public void EndTurn()
        {
            throw new NotImplementedException();
        }
        
        public IPlayer GetWinner()
        {
            throw new NotImplementedException();
        }
    }
}
