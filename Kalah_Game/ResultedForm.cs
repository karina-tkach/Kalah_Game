using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalah_Game
{
    public partial class ResultedForm : Form
    {
        private int firstPlayerScore;

        public int FirstPlayerScore
        {
            get { return firstPlayerScore; }
            set { firstPlayerScore = value; }
        }

        private int secondPlayerScore;

        public int SecondPlayerScore
        {
            get { return secondPlayerScore; }
            set { secondPlayerScore = value; }
        }

        private string secondPlayerName;

        public string SecondPlayerName
        {
            get { return secondPlayerName; }
            set { secondPlayerName = value; }
        }

        public ResultedForm(int playerOneScore, int playerTwoScore, string secondPlayerName)
        {
            InitializeComponent();
            this.MaximumSize = new Size(1050, 570);

            this.firstPlayerScore = playerOneScore;
            this.secondPlayerScore = playerTwoScore;
            this.secondPlayerName = secondPlayerName;
        }

        private void ResultedForm_Load(object sender, EventArgs e)
        {
            scoreLabel.BackColor = Color.Transparent;
            winnerLabel.BackColor = Color.Transparent;

            if (firstPlayerScore > secondPlayerScore)
            {
                winnerLabel.Text = secondPlayerName == "Computer" ? "Player Won!" : "Player One Won!";
            }
            else if (secondPlayerScore > firstPlayerScore)
            {
                winnerLabel.Text = secondPlayerName == "Computer" ? "Computer Won!" : "Player Two Won!";
            }
            else
            {
                winnerLabel.Text = "Draw!";
            }
            scoreLabel.Text = $"Score: {firstPlayerScore}:{secondPlayerScore}";
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
