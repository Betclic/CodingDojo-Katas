using System.Collections.Generic;
using System.Linq;

namespace Tcg.Core
{
    public abstract class Strategy
    {
        public abstract Card PickCard(int availableMana, int currentHealth, IList<Card> hand);
    }

    public class DummyStrategy : Strategy
    {
        /**
          * This strategy plays the first affordable card.
          */
        public override Card PickCard(int availableMana, int currentHealth, IList<Card> hand)
        {
            var card = hand.FirstOrDefault(c => c.Value <= availableMana);
            return card;
        }
    }

    public class KamikazeStrategy : Strategy
    {

        public override Card PickCard(int availableMana, int currentHealth, IList<Card> hand)
        {
            Card card = null;
            /*
             * This strategy plays the highest affordable cards first and only for attacking. No healing is used regardless of the players health.
             */
            return card;
        }
    }

    public class CautiousStrategy : Strategy
    {

        public override Card PickCard(int availableMana, int currentHealth, IList<Card> hand)
        {
            Card card = null;
            /*
             * This strategy plays the highest affordable cards for attacking. It switches into healing with the lowest possible cards when the players health falls below 20.
             */
            return card;
        }
    }
}
