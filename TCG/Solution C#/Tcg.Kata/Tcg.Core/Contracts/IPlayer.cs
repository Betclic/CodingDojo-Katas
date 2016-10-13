using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tcg.Core
{
    public interface IPlayer
    {
        string Name { get; }
        int Health { get; }
        int Mana { get; }
        int ManaSlots { get; }
        Strategy Strategy { get; }
        
        IList<Card> Deck { get; }
        IList<Card> Hand { get; }

        Task<Card> DetermineNextMoveAsync(IPlayer opponentPlayer);
        void PlayCard(Card card, IPlayer opponentPlayer);
        void ReceiveDamage(int value);
        void ReceiveHealth(int health);
    }
}