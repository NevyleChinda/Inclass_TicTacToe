using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows;

/*
 * Name: Nevyle Chinda
 * Date: October 2, 2026
 * Description: Code-behind for the Tic Tac Toe GUI. No game logic yet. 
 */

namespace Inclass
{
    public partial class MainWindow : Window
    {

        // Declarations
        private const string Xmark = "X";
        private const string Omark = "O";
        private string currentPlayer = Xmark;
        private string startingPlayer = Xmark;
        private int movesCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}