using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tcg.Core
{
    public class Player : IPlayer
    {
        // MAXIMUM_HAND_SIZE = 5;
        // STARTING_HAND_SIZE = 3;
        // STARTING_HEALTH = 30;
        // DmgCards => Action.DAMAGE : 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8;
        // HealCards => Action.HEAL :  2, 3, 3, 4, 4, 5;
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int ManaSlots { get; set; }
        public IList<Card> Deck { get; private set; }
        public IList<Card> Hand { get; private set; }

        public Strategy Strategy { get; set; }
        
        public Player(string name = null, Strategy strategy = null)
        {
            Strategy = strategy;
            if (!string.IsNullOrEmpty(name))
                Name = name;
            
            Hand = new List<Card>();
            Deck = new List<Card>();          
        }

        public Player(string name, int health, int mana, int manaSlots, List<Card> deck, List<Card> hand, Strategy strategy = null)
        {
            Name = name;
            Health = health;
            Mana = mana;
            ManaSlots = manaSlots;
            Strategy = strategy;
            Deck = deck;
            Hand = hand;
        }

        public int GetNumberOfDeckCardsWithManaCost(int cardValue)
        {
            throw new NotImplementedException();
        }
        
        public void PlayCard(Card card, IPlayer opponent)
        {
            throw new NotImplementedException();
        }

        public void ReceiveDamage(int damage)
        {
            throw new NotImplementedException();
        }
        public void ReceiveHealth(int health)
        {
            throw new NotImplementedException();
        }

        public Task<Card> DetermineNextMoveAsync(IPlayer opponentPlayer)
        {
            throw new NotImplementedException();
        }
    }
}
