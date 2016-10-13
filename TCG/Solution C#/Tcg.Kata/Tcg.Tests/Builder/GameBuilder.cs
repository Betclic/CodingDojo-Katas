using Tcg.Core;

namespace Tcg.Tests.Builder
{
    internal class GameBuilder
    {
        Player activePlayer = PlayerBuilder.anyPlayer();
        Player opponentPlayer = PlayerBuilder.anyPlayer();

        Game game;

        public static GameBuilder aGame()
        {
            return new GameBuilder();
        }

        public static Game anyGame()
        {
            return aGame().Build();
        }

        public Game Build()
        {
            return new Game(activePlayer, opponentPlayer);
        }

        public GameBuilder withActivePlayer(Player player)
        {
            activePlayer = player;
            return this;
        }

        public GameBuilder withOpponentPlayer(Player player)
        {
            opponentPlayer = player;
            return this;
        }
    }
}
