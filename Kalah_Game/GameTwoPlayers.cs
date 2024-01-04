using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalah_Game
{
    public partial class GameTwoPlayers : Form
    {
        Board board = new Board("Player Two");

        private int moveIndex = -1;
        private Button[] firstPlayerButtons;
        private Button[] secondPlayerButtons;
        public GameTwoPlayers()
        {
            InitializeComponent();
            this.MaximumSize = new Size(1050, 570);
            scoreLabel.BackColor = Color.Transparent;
            turnLabel.BackColor = Color.Transparent;
            moveStatusLabel.BackColor = Color.Transparent;

            firstPlayerButtons = new Button[] { button1, button2, button3, button4, button5,
            button6, playerOneMancala};
            secondPlayerButtons = new Button[] { btn1, btn2, btn3, btn4, btn5,
            btn6, playerTwoMancala};

            SetButtonsBorder();
            DisablePlayerTwoButtons();
        }
        private void SetButtonsBorder()
        {
            foreach (Button button in firstPlayerButtons)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.Red;
                button.FlatAppearance.BorderSize = 3;
                button.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            }
            playerOneMancala.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            foreach (Button button in secondPlayerButtons)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.Blue;
                button.FlatAppearance.BorderSize = 3;
                button.FlatAppearance.MouseOverBackColor = Color.LightSkyBlue;
            }
            playerTwoMancala.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
        }
        private void playerOneButtons_Click(object sender, EventArgs e)
        {
            string buttonName = ((Button)sender).Name;
            moveIndex = int.Parse(buttonName[^1..]) - 1;

            if (board.IsPlayerOneTurn && !board.IsGameEnded)
            {
                board.MakeMove(moveIndex);
                moveIndex = -1;
                ChangeLabels();
                DisplayValues();
            }
            if (!board.IsGameEnded && !board.IsPlayerOneTurn)
            {
                DisablePlayerOneButtons();
                EnablePlayerTwoButtons();
            }

            CheckEndGame();
        }
        private void playerTwoButtons_Click(object sender, EventArgs e)
        {
            string buttonName = ((Button)sender).Name;
            moveIndex = int.Parse(buttonName.Substring(buttonName.Length - 1)) - 1;

            if (!board.IsPlayerOneTurn && !board.IsGameEnded)
            {
                board.MakeMove(moveIndex);
                moveIndex = -1;
                ChangeLabels();
                DisplayValues();
            }
            if (!board.IsGameEnded && board.IsPlayerOneTurn)
            {
                DisablePlayerTwoButtons();
                EnablePlayerOneButtons();
            }

            CheckEndGame();
        }
        private void DisablePlayerOneButtons()
        {
            foreach (var button in firstPlayerButtons)
            {
                button.Enabled = false;
            }
        }
        private void EnablePlayerOneButtons()
        {
            foreach (var button in firstPlayerButtons)
            {
                button.Enabled = true;
            }
        }
        private void DisablePlayerTwoButtons()
        {
            foreach (var button in secondPlayerButtons)
            {
                button.Enabled = false;
            }
        }
        private void EnablePlayerTwoButtons()
        {
            foreach (var button in secondPlayerButtons)
            {
                button.Enabled = true;
            }
        }
        private async void CheckEndGame()
        {
            if (board.IsGameEnded)
            {
                await Task.Delay(1000);

                ResultedForm form = new ResultedForm(board.PlayerOneStore, board.PlayerTwoStore, "Player Two");

                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }
        private void DisplayValues()
        {
            int[] playerOneStones = board.PlayerOneSlots;
            int[] playerTwoStones = board.PlayerTwoSlots;
            for (int i = 0; i < firstPlayerButtons.Length - 1; i++)
            {
                firstPlayerButtons[i].Text = playerOneStones[i].ToString();
                secondPlayerButtons[i].Text = playerTwoStones[i].ToString();

            }
            playerOneMancala.Text = board.PlayerOneStore.ToString();
            playerTwoMancala.Text = board.PlayerTwoStore.ToString();
        }
        private void ChangeLabels()
        {
            turnLabel.Text = (board.IsPlayerOneTurn) ? "Player 1's turn" : "Player 2's turn";
            scoreLabel.Text = $"Player One: {board.PlayerOneStore}   Player Two: {board.PlayerTwoStore}";
            moveStatusLabel.Text = board.MoveStatus;
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }
    }
}
