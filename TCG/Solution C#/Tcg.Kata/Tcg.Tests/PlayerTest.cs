using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tcg.Core;
using Tcg.Tests.Builder;
using Action = Tcg.Core.Action;

namespace Tcg.Tests
{
    [TestClass]
    public class PlayerTest
    {
        private Player Player { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Player = new Player();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayerShouldHave30InitialHealth()
        {
            Assert.AreEqual(30, Player.Health);
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayerShouldHave0InitialMana()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        [Ignore]
        public void CardDeckShouldContainInitialCards()
        {
            // DmgCards => Action.DAMAGE : 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8;
            // HealCards => Action.HEAL :  2, 3, 3, 4, 4, 5;
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayerStartsWithEmptyHand()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void DrawingACardShouldMoveOneCardFromDeckIntoHand()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayerShouldTakeOneDamageWhenDrawingFromEmptyDeck()
        {
            //Player = PlayerBuilder.aPlayer().withNoCardsInDeck().Build();


            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void ShouldDiscardDrawnCardWhenHandSizeIsFive()
        {
            //Given Deck : 1 card , Hand : 5 cards

            //When Draw

            //Then Deck : 0, Hand : 5
            Assert.Fail();
        }


        [TestCategory("Player")]
        [TestMethod]
        public void PlayingCardsReducesPlayersMana()
        {
            //Given Mana : 10 , Hand : (8,1)

            //When Play Cards

            //Then Mana : 1
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayingCardsRemovesThemFromHand()
        {
            //Given Hand : (1, 2, 2, 3)

            //When Play 3 and 2

            //Then Hand : (1, 2)
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlayingCardWithInsufficientManaShouldFail()
        {
            //Given Mana : 3  Hand : (4,4,4)

            //When Play 4

            //Then Exception
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayingCardCausesDamageToOpponent()
        {
            //Player = PlayerBuilder.aPlayer().withCardsInHand(Action.DAMAGE, 2, 3, 4).Build();
            //var opponent = PlayerBuilder.anyPlayer();
            

            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayerWithSufficientManaCanPlayCards()
        {
            Assert.Fail();
        }


        [TestMethod]
        [TestCategory("Player")]
        public void PlayerWithInsufficientManaCannotPlayCards()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayerWithEmptyHandCannotPlayCards()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayingCardAsHealingRestoresHealth()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Player")]
        public void PlayerCannotHealAbove30Health()
        {
            Assert.Fail();
        }
    }
}
