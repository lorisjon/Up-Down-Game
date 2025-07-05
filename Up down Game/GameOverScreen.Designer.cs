namespace Up_down_Game
{
    partial class GameOverScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverScreen));
            restartbutton = new Button();
            exitbutton = new Button();
            Scorelabel = new Label();
            Highscorelabel = new Label();
            scoreanouncelabel = new Label();
            SuspendLayout();
            // 
            // restartbutton
            // 
            restartbutton.AutoSize = true;
            restartbutton.Location = new Point(281, 82);
            restartbutton.Margin = new Padding(2, 2, 2, 2);
            restartbutton.Name = "restartbutton";
            restartbutton.Size = new Size(90, 30);
            restartbutton.TabIndex = 0;
            restartbutton.Text = "Restart";
            restartbutton.UseVisualStyleBackColor = true;
            restartbutton.Click += restartbutton_Click;
            // 
            // exitbutton
            // 
            exitbutton.AutoSize = true;
            exitbutton.Location = new Point(302, 162);
            exitbutton.Margin = new Padding(2, 2, 2, 2);
            exitbutton.Name = "exitbutton";
            exitbutton.Size = new Size(90, 30);
            exitbutton.TabIndex = 1;
            exitbutton.Text = "Menu";
            exitbutton.UseVisualStyleBackColor = true;
            exitbutton.Click += quitbutton_Click;
            // 
            // Scorelabel
            // 
            Scorelabel.AutoSize = true;
            Scorelabel.Location = new Point(205, 185);
            Scorelabel.Margin = new Padding(2, 0, 2, 0);
            Scorelabel.Name = "Scorelabel";
            Scorelabel.Size = new Size(177, 20);
            Scorelabel.TabIndex = 2;
            Scorelabel.Text = "Hier steht dann der Score";
            // 
            // Highscorelabel
            // 
            Highscorelabel.AutoSize = true;
            Highscorelabel.Location = new Point(310, 258);
            Highscorelabel.Margin = new Padding(2, 0, 2, 0);
            Highscorelabel.Name = "Highscorelabel";
            Highscorelabel.Size = new Size(163, 20);
            Highscorelabel.TabIndex = 3;
            Highscorelabel.Text = "und Hier der Highscore";
            // 
            // scoreanouncelabel
            // 
            scoreanouncelabel.AutoSize = true;
            scoreanouncelabel.Location = new Point(450, 207);
            scoreanouncelabel.Margin = new Padding(2, 0, 2, 0);
            scoreanouncelabel.Name = "scoreanouncelabel";
            scoreanouncelabel.Size = new Size(112, 20);
            scoreanouncelabel.TabIndex = 4;
            scoreanouncelabel.Text = "score announce";
            // 
            // GameOverScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(scoreanouncelabel);
            Controls.Add(Highscorelabel);
            Controls.Add(Scorelabel);
            Controls.Add(exitbutton);
            Controls.Add(restartbutton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "GameOverScreen";
            Text = "GameOverScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button restartbutton;
        private Button exitbutton;
        private Label Scorelabel;
        private Label Highscorelabel;
        private Label scoreanouncelabel;
    }
}