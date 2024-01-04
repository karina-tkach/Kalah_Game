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
    public partial class GameWithComputer : Form
    {
        Board board = new Board("Computer");

        private int moveIndex = -1;
        private Button[] playerButtons;
        private Button[] computerButtons;
        private ComputerMoveCalculator computerMove;
        public GameWithComputer()
        {
            InitializeComponent();

            this.MaximumSize = new Size(1050, 570);
            scoreLabel.BackColor = Color.Transparent;
            turnLabel.BackColor = Color.Transparent;
            moveStatusLabel.BackColor = Color.Transparent;

            playerButtons = new Button[] { button1, button2, button3, button4, button5,
            button6, playerMancala};
            computerButtons = new Button[] { button7, button8, button9, button10, button11,
            button12, computerMancala};
            computerMove = new ComputerMoveCalculator(board);

            SetButtonsBorder();
        }
        private void SetButtonsBorder()
        {
            foreach (Button button in playerButtons)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.Red;
                button.FlatAppearance.BorderSize = 3;
                button.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            }
            playerMancala.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            foreach (Button button in computerButtons)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderColor = Color.Blue;
                button.FlatAppearance.BorderSize = 3;
            }
            computerMancala.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            string buttonName = ((Button)sender).Name;
            moveIndex = int.Parse(buttonName[^1..]) - 1;
            MakeMove();
        }
        private async void MakeMove()
        {
            if (board.IsPlayerOneTurn)
            {
                board.MakeMove(moveIndex);
                moveIndex = -1;
                ChangeLabels();
                DisplayValues();
            }
            if (!board.IsGameEnded)
            {
                DisablePlayerButtons();
                while (!board.IsPlayerOneTurn && !board.IsGameEnded)
                {
                    int index = computerMove.CalculateMove();
                    board.MakeMove(index); await Task.Delay(2300);
                    computerButtons[index].BackColor = Color.LightSkyBlue;
                    await Task.Delay(600);
                    computerButtons[index].BackColor = Color.WhiteSmoke;
                    ChangeLabels();
                    DisplayValues();
                }
                EnablePlayerButtons();
            }
            CheckEndGame();
        }
        private void DisablePlayerButtons()
        {
            foreach (var button in playerButtons)
            {
                button.Enabled = false;
            }
        }
        private void EnablePlayerButtons()
        {
            foreach (var button in playerButtons)
            {
                button.Enabled = true;
            }
        }
        private async void CheckEndGame()
        {
            if (board.IsGameEnded)
            {
                await Task.Delay(1000);

                ResultedForm form = new ResultedForm(board.PlayerOneStore, board.PlayerTwoStore, "Computer");

                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }
        private void DisplayValues()
        {
            int[] playerStones = board.PlayerOneSlots;
            int[] computerStones = board.PlayerTwoSlots;
            for (int i = 0; i < playerButtons.Length - 1; i++)
            {
                playerButtons[i].Text = playerStones[i].ToString();
                computerButtons[i].Text = computerStones[i].ToString();

            }
            playerMancala.Text = board.PlayerOneStore.ToString();
            computerMancala.Text = board.PlayerTwoStore.ToString();
        }
        private void ChangeLabels()
        {
            turnLabel.Text = (board.IsPlayerOneTurn) ? "Player's turn" : "Computer's turn";
            scoreLabel.Text = $"Player: {board.PlayerOneStore}   Computer: {board.PlayerTwoStore}";
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
