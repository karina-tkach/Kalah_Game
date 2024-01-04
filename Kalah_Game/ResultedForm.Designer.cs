namespace Kalah_Game
{
    partial class ResultedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultedForm));
            scoreLabel = new Label();
            backToMenuButton = new Button();
            exitButton = new Button();
            winnerLabel = new Label();
            SuspendLayout();
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            scoreLabel.ForeColor = Color.White;
            scoreLabel.Location = new Point(313, 145);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(336, 86);
            scoreLabel.TabIndex = 0;
            scoreLabel.Text = "Score: X:Y";
            // 
            // backToMenuButton
            // 
            backToMenuButton.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            backToMenuButton.Location = new Point(392, 273);
            backToMenuButton.Name = "backToMenuButton";
            backToMenuButton.Size = new Size(296, 79);
            backToMenuButton.TabIndex = 1;
            backToMenuButton.Text = "Back to menu";
            backToMenuButton.UseVisualStyleBackColor = true;
            backToMenuButton.Click += backToMenuButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            exitButton.Location = new Point(392, 381);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(296, 69);
            exitButton.TabIndex = 2;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // winnerLabel
            // 
            winnerLabel.AutoSize = true;
            winnerLabel.Font = new Font("Segoe UI", 45F, FontStyle.Bold, GraphicsUnit.Point);
            winnerLabel.ForeColor = Color.White;
            winnerLabel.Location = new Point(321, 37);
            winnerLabel.Name = "winnerLabel";
            winnerLabel.Size = new Size(242, 81);
            winnerLabel.TabIndex = 3;
            winnerLabel.Text = "X Won!";
            // 
            // ResultedForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1034, 531);
            ControlBox = false;
            Controls.Add(winnerLabel);
            Controls.Add(exitButton);
            Controls.Add(backToMenuButton);
            Controls.Add(scoreLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ResultedForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Result";
            Load += ResultedForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scoreLabel;
        private Button backToMenuButton;
        private Button exitButton;
        private Label winnerLabel;
    }
}