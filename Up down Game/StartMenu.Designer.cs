namespace Up_down_Game
{
    partial class StartMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            startgamebutton = new Button();
            quitbutton = new Button();
            tutorialbutton = new Button();
            SuspendLayout();
            // 
            // startgamebutton
            // 
            startgamebutton.AutoSize = true;
            startgamebutton.Location = new Point(142, 133);
            startgamebutton.Name = "startgamebutton";
            startgamebutton.Size = new Size(112, 35);
            startgamebutton.TabIndex = 0;
            startgamebutton.Text = "Start Game";
            startgamebutton.UseVisualStyleBackColor = true;
            startgamebutton.Click += startGame_Click;
            // 
            // quitbutton
            // 
            quitbutton.AutoSize = true;
            quitbutton.Location = new Point(178, 99);
            quitbutton.Name = "quitbutton";
            quitbutton.Size = new Size(112, 35);
            quitbutton.TabIndex = 2;
            quitbutton.Text = "Quit";
            quitbutton.UseVisualStyleBackColor = true;
            quitbutton.Click += quitbutton_Click;
            // 
            // tutorialbutton
            // 
            tutorialbutton.AutoSize = true;
            tutorialbutton.Location = new Point(172, 195);
            tutorialbutton.Name = "tutorialbutton";
            tutorialbutton.Size = new Size(112, 35);
            tutorialbutton.TabIndex = 3;
            tutorialbutton.Text = "Tutorial";
            tutorialbutton.UseVisualStyleBackColor = true;
            tutorialbutton.Click += tutorialbutton_Click;
            // 
            // StartMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(302, 365);
            Controls.Add(tutorialbutton);
            Controls.Add(quitbutton);
            Controls.Add(startgamebutton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StartMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StartMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startgamebutton;
        private Button quitbutton;
        private Button tutorialbutton;
    }
}