using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalah_Game
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            gameTitle.Parent = pictureBox1;
            gameTitle.BackColor = Color.Transparent;
            this.MaximumSize = new Size(1050, 570);
        }

        private void computerModeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameWithComputer game = new GameWithComputer();
            game.ShowDialog();
            this.Close();
        }

        private void twoPlayersModeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameTwoPlayers game = new GameTwoPlayers();
            game.ShowDialog();
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
