using System.Windows;
using Tcg.Core;
using Tcg.Kata.ViewModels;

namespace Tcg.Kata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MiniWindow : Window
    {

        public GameViewModel vm { get; set; }

        public MiniWindow()
        {
            InitializeComponent();

            var player1 = new Player("Me", null);
            var player2 = new Player("Bender", new DummyStrategy());
            //var player2 = new Player("Skynet", new KamikazeStrategy());
            //var player2 = new Player("Wall-E", new CautiousStrategy());

            var game = new Game(player1, player2);

            vm = new GameViewModel(game, player1, player2);

            DataContext = vm;   

            vm.BeginOfTurn();
        }
    }
}
