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

            // Check for a winner after each move
            if (CheckForWinner())
            {
                MessageBox.Show($"{GetPlayerName(currentPlayer)} ({currentPlayer}) is the Winner!",
                                "Winner Announcement",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                if (currentPlayer == Xmark)
                {
                    txtXScore.Text = (int.Parse(txtXScore.Text) + 1).ToString();
                }
                else
                {
                    txtOScore.Text = (int.Parse(txtOScore.Text) + 1).ToString();
                }

                ResetBoard();
            }
            else if (movesCount == 9)
            {
                MessageBox.Show("It's a tie! Nobody wins this round.",
                                "Tie Game",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                txtCatsScore.Text = (int.Parse(txtCatsScore.Text) + 1).ToString();
                ResetBoard();
            }
            else
            {
                currentPlayer = (currentPlayer == Xmark) ? Omark : Xmark;
                txtCurrentPlayer.Text = currentPlayer;
            }
        }


        // Event handler for the choose starting player button
        private void btnChooseStart_Click(object sender, RoutedEventArgs e)
        {
            // First, checks if a move has been made. If so, it will not allow the starting player to be changed.
            if (movesCount > 0)
            {
                MessageBox.Show("Cannot change starting player after a move has been made. You are currnetly playing");
                return;
            }
            MessageBoxResult choice = MessageBox.Show(
                $"Should {GetPlayerName(Xmark)} (X) go first?\n\nYes = X goes first\nNo = O goes first",
                "Choose Starting Player",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            startingPlayer = (choice == MessageBoxResult.Yes) ? Xmark : Omark;
            currentPlayer = startingPlayer;
            txtCurrentPlayer.Text = currentPlayer;

        }

        // Event handler for the reset button
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtXScore.Text = "0";
            txtOScore.Text = "0";
            txtCatsScore.Text = "0";
        }

        // Event handler for the exit button
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Method to check for a winner
        private bool CheckForWinner()
        {
            if (CheckLine(btn00, btn01, btn02)) return true;
            if (CheckLine(btn10, btn11, btn12)) return true;
            if (CheckLine(btn20, btn21, btn22)) return true;

            if (CheckLine(btn00, btn10, btn20)) return true;
            if (CheckLine(btn01, btn11, btn21)) return true;
            if (CheckLine(btn02, btn12, btn22)) return true;

            if (CheckLine(btn00, btn11, btn22)) return true;
            if (CheckLine(btn02, btn11, btn20)) return true;

            return false;
        }

        // Method to check if a line of buttons has the same content (i.e., a winning line)
        private bool CheckLine(Button b1, Button b2, Button b3)
        {
            if (b1.Content.ToString() == currentPlayer &&
                b2.Content.ToString() == currentPlayer &&
                b3.Content.ToString() == currentPlayer)
            {
                HighlightSquare(b1);
                HighlightSquare(b2);
                HighlightSquare(b3);
                return true;
            }
            return false;
        }

        // Method to highlight a winning square
        private void HighlightSquare(Button square)
        {
            square.IsEnabled = true;
            square.Background = Brushes.LightGreen;
        }

        // Method to get the player's name based on their mark (X or O)
        private string GetPlayerName(string mark)
        {
            string name = (mark == Xmark) ? txtXPlayer.Text.Trim() : txtOPlayer.Text.Trim();
            return (name == "") ? $"Player {mark}" : name;
        }

        // Method that resets the game board ad move count.
        private void ResetBoard()
        {
            ResetSquare(btn00);
            ResetSquare(btn01);
            ResetSquare(btn02);
            ResetSquare(btn10);
            ResetSquare(btn11);
            ResetSquare(btn12);
            ResetSquare(btn20);
            ResetSquare(btn21);
            ResetSquare(btn22);

            movesCount = 0;
            currentPlayer = startingPlayer;
            txtCurrentPlayer.Text = currentPlayer;
        }

        // Method to reset each individual square
        private void ResetSquare(Button square)
        {
            square.Content = "";
            square.IsEnabled = true;
            square.ClearValue(Button.BackgroundProperty);
        }
    }
}

