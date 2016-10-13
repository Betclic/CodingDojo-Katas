using System.Collections.Generic;
using System.Linq;

namespace Tcg.Core
{
    public class Card
    {
        public static List<Card> BuildCardList(Action action, params int[] cards)
        {
            return cards.Select(c => new Card(c, action)).ToList();
        }

        public int Value { get; }

        public Action Action {get;}

        public Card(int value, Action action = Action.DAMAGE)
        {
            Value = value;
            Action = action;
        }

        public override string ToString()
        {
            return "" + Value;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;

            Card card = (Card)obj;
            if (Value != card.Value || Action != card.Action) return false;

            return true;
        }
    }

    public enum Action
    {
        DAMAGE,
        HEAL
    }
}