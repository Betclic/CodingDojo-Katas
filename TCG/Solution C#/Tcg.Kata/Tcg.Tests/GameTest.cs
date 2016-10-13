using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tcg.Core;

namespace Tcg.Tests
{
    [TestClass]
    public class GameTest
    {
        private Game game;

        [TestMethod]
        [TestCategory("Game")]
        public void GameShouldHaveTwoPlayers()
        {
            //game = GameBuilder.anyGame();

            Assert.IsNotNull(game.ActivePlayer);
            Assert.IsNotNull(game.OpponentPlayer);
        }

        [TestMethod]
        [TestCategory("Game")]
        public void StartingPlayerShouldHaveStartingHandOfThreeCardsFromHisDeck()
        {

            Assert.AreEqual(3, game.ActivePlayer.Hand.Count);
            Assert.AreEqual(22, game.ActivePlayer.Deck.Count);
        }

        [TestMethod]
        [TestCategory("Game")]
        public void NonStartingPlayerShouldHaveStartingHandOfThreeCardsFromHisDeck()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Game")]
        public void ActivePlayerShouldSwitchOnEndOfTurn()
        {
            Player player1 = null;
            Player player2 = null;

            //game setup

            game.EndTurn();
            Assert.AreEqual(player2, game.ActivePlayer);
            game.EndTurn();
            Assert.AreEqual(player1, game.ActivePlayer);
        }

        [TestMethod]
        [TestCategory("Game")]
        public void ActivePlayerShouldReceiveOneManaSlotOnBeginningOfTurn()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Game")]
        public void ActivePlayerShouldNotReceiveOneManaSlotIfAlready10ManaSlots()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Game")]
        public void ActivePlayerShouldRefillManaOnBeginningOfTurn()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Game")]
        public void ActivePlayerShouldDrawCardOnBeginningOfTurn()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Game")]
        public void PlayerWithOneHealthAndEmptyDeckShouldDieFromBleedingOutOnBeginningOfTurn()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Game")]
        public void OpponentLoosesWhenHealthIsZero()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Game")]
        public void OngoingGameHasNoWinner()
        {
            Assert.Fail();
        }


    }
}
