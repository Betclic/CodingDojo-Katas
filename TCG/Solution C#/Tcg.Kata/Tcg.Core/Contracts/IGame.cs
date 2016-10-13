namespace Tcg.Core
{
    public interface IGame
    {
        IPlayer ActivePlayer { get; set; }
        IPlayer OpponentPlayer { get; set; }
        void EndTurn();
        void BeginTurn();
        IPlayer GetWinner();
    }
}