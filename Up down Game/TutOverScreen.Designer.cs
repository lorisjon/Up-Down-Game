namespace Up_down_Game
{
    partial class TutOverScreen
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
            components = new System.ComponentModel.Container();
            replaybutton = new Button();
            forrealbutton = new Button();
            mainmenubutton = new Button();
            Scorelabel = new Label();
            scoreannouncelabel = new Label();
            closeTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // replaybutton
            // 
            replaybutton.AutoSize = true;
            replaybutton.Location = new Point(339, 134);
            replaybutton.Name = "replaybutton";
            replaybutton.Size = new Size(161, 35);
            replaybutton.TabIndex = 0;
            replaybutton.Text = "Replay Tutorial";
            replaybutton.UseVisualStyleBackColor = true;
            replaybutton.Click += replaybutton_Click;
            // 
            // forrealbutton
            // 
            forrealbutton.AutoSize = true;
            forrealbutton.Location = new Point(339, 194);
            forrealbutton.Name = "forrealbutton";
            forrealbutton.Size = new Size(152, 35);
            forrealbutton.TabIndex = 1;
            forrealbutton.Text = "Play For real";
            forrealbutton.UseVisualStyleBackColor = true;
            forrealbutton.Click += forrealbutton_Click;
            // 
            // mainmenubutton
            // 
            mainmenubutton.AutoSize = true;
            mainmenubutton.Location = new Point(356, 253);
            mainmenubutton.Name = "mainmenubutton";
            mainmenubutton.Size = new Size(112, 35);
            mainmenubutton.TabIndex = 2;
            mainmenubutton.Text = "Main Menu";
            mainmenubutton.UseVisualStyleBackColor = true;
            mainmenubutton.Click += mainmenubutton_Click;
            // 
            // Scorelabel
            // 
            Scorelabel.AutoSize = true;
            Scorelabel.Location = new Point(408, 350);
            Scorelabel.Name = "Scorelabel";
            Scorelabel.Size = new Size(213, 25);
            Scorelabel.TabIndex = 3;
            Scorelabel.Text = "Hier steht dann der Score";
            // 
            // scoreannouncelabel
            // 
            scoreannouncelabel.AutoSize = true;
            scoreannouncelabel.Location = new Point(378, 317);
            scoreannouncelabel.Name = "scoreannouncelabel";
            scoreannouncelabel.Size = new Size(136, 25);
            scoreannouncelabel.TabIndex = 4;
            scoreannouncelabel.Text = "score announce";
            // 
            // closeTimer
            // 
            closeTimer.Enabled = true;
            closeTimer.Interval = 10;
            closeTimer.Tick += closeTimer_Tick;
            // 
            // TutOverScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(scoreannouncelabel);
            Controls.Add(Scorelabel);
            Controls.Add(mainmenubutton);
            Controls.Add(forrealbutton);
            Controls.Add(replaybutton);
            Name = "TutOverScreen";
            Text = "TutOverScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button replaybutton;
        private Button forrealbutton;
        private Button mainmenubutton;
        private Label Scorelabel;
        private Label scoreannouncelabel;
        private System.Windows.Forms.Timer closeTimer;
    }
}