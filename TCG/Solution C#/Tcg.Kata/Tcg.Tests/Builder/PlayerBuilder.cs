using System.Collections.Generic;
using Tcg.Core;

namespace Tcg.Tests.Builder
{
    internal class PlayerBuilder
    {
        private int _health = 30;
        private int _manaSlots = 0;
        private int _mana = 0;

        private List<Card> DmgCards = Card.BuildCardList(Action.DAMAGE, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8);
        private List<Card> HealCards = Card.BuildCardList(Action.HEAL, 2, 3, 4, 5, 5, 5, 5);

        private List<Card> _deck = new List<Card>();
        private List<Card> _hand = new List<Card>();

        private static int playerNo = 0;
        private readonly string _name = "Player " + playerNo++;

        public PlayerBuilder()
        {
            InitDeck();
        }

        public static PlayerBuilder aPlayer()
        {
            return new PlayerBuilder();
        }

        public static Player anyPlayer()
        {
            return aPlayer().Build();
        }

        public Player Build()
        {
            return new Player(_name, _health, _mana, _manaSlots, _deck, _hand);
        }

        private void InitDeck()
        {
            _deck = new List<Card>();
            _deck.AddRange(DmgCards);
            _deck.AddRange(HealCards);
        }

        public PlayerBuilder withCardsInDeck(Action action, params int[] manaCosts)
        {
            this._deck = Card.BuildCardList(action, manaCosts);
            return this;
        }

        public PlayerBuilder withNoCardsInHand()
        {
            this._hand = new List<Card>();
            return this;
        }

        public PlayerBuilder withHealth(int health)
        {
            this._health = health;
            return this;
        }

        public PlayerBuilder withNoCardsInDeck()
        {
            this._deck = new List<Card>();
            return this;
        }

        public PlayerBuilder withCardsInHand(Action action, params int[] manaCosts)
        {
            this._hand = Card.BuildCardList(action, manaCosts);
            return this;
        }

        public PlayerBuilder withManaSlots(int v)
        {
            this._manaSlots = v;
            return this;
        }

        public PlayerBuilder withMana(int mana)
        {
            this._mana = mana;
            return this;
        }
    }
}
