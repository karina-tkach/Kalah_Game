namespace Kalah_Game
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            pictureBox1 = new PictureBox();
            computerModeButton = new Button();
            exitButton = new Button();
            gameTitle = new Label();
            twoPlayersModeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1033, 531);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // computerModeButton
            // 
            computerModeButton.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            computerModeButton.Location = new Point(386, 154);
            computerModeButton.Name = "computerModeButton";
            computerModeButton.Size = new Size(294, 74);
            computerModeButton.TabIndex = 1;
            computerModeButton.Text = "Play vs Computer";
            computerModeButton.UseVisualStyleBackColor = true;
            computerModeButton.Click += computerModeButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            exitButton.Location = new Point(386, 359);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(294, 74);
            exitButton.TabIndex = 2;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // gameTitle
            // 
            gameTitle.AutoSize = true;
            gameTitle.BackColor = Color.WhiteSmoke;
            gameTitle.Font = new Font("Segoe UI", 50.25F, FontStyle.Bold, GraphicsUnit.Point);
            gameTitle.ForeColor = Color.White;
            gameTitle.Location = new Point(330, 0);
            gameTitle.Name = "gameTitle";
            gameTitle.Size = new Size(411, 89);
            gameTitle.TabIndex = 4;
            gameTitle.Text = "Kalah Game";
            // 
            // twoPlayersModeButton
            // 
            twoPlayersModeButton.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            twoPlayersModeButton.Location = new Point(386, 252);
            twoPlayersModeButton.Name = "twoPlayersModeButton";
            twoPlayersModeButton.Size = new Size(294, 74);
            twoPlayersModeButton.TabIndex = 5;
            twoPlayersModeButton.Text = "Play vs Friend";
            twoPlayersModeButton.UseVisualStyleBackColor = true;
            twoPlayersModeButton.Click += twoPlayersModeButton_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 531);
            ControlBox = false;
            Controls.Add(twoPlayersModeButton);
            Controls.Add(gameTitle);
            Controls.Add(exitButton);
            Controls.Add(computerModeButton);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button computerModeButton;
        private Button exitButton;
        private Label gameTitle;
        private Button twoPlayersModeButton;
    }
}