using System.Windows.Media;
using Tcg.Core;

namespace Tcg.Kata.ViewModels
{
    public class CardViewModel : BaseViewModel
    {
        public Card Card { get; set; }

        public Action Action { get { return Card.Action; } }
        public int Value { get { return Card.Value; } }

        public string Background { get { return Card.Action == Action.DAMAGE ? "Resources/damage.png" : "Resources/heal.png"; } }
        public Brush Color { get { return Card.Action == Action.DAMAGE ? new SolidColorBrush(Colors.DarkRed) : new SolidColorBrush(Colors.DarkGreen); } }

        public CardViewModel(Card card)
        {
            Card = card;
        }
    }
}