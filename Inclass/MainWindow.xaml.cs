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

            // Attach the same event handler to all board buttons
            btn00.Click += BoardButton_Click;
            btn01.Click += BoardButton_Click;
            btn02.Click += BoardButton_Click;
            btn10.Click += BoardButton_Click;
            btn11.Click += BoardButton_Click;
            btn12.Click += BoardButton_Click;
            btn20.Click += BoardButton_Click;
            btn21.Click += BoardButton_Click;
            btn22.Click += BoardButton_Click;

            // Attach event handlers for other buttons
            btnChooseStart.Click += btnChooseStart_Click;
            btnReset.Click += btnReset_Click;
            btnExit.Click += btnExit_Click;

            txtCurrentPlayer.Text = currentPlayer;
        }
        // Event handler for board button clicks
        private void BoardButton_Click(object sender, RoutedEventArgs e)
        {
            Button square = (Button)sender;

            square.Content = currentPlayer;
            square.IsEnabled = false;
            movesCount++;

        }
    }
}