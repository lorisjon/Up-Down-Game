namespace Up_down_game_5
{
    partial class Tutorial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutorial));
            movetimer = new System.Windows.Forms.Timer(components);
            generellTimer = new System.Windows.Forms.Timer(components);
            speeduptimer = new System.Windows.Forms.Timer(components);
            p1 = new PictureBox();
            p2 = new PictureBox();
            spawnTimer = new System.Windows.Forms.Timer(components);
            Spielbeginnen = new Label();
            gameOver = new Label();
            pauseButton = new PictureBox();
            delayTimer = new System.Windows.Forms.Timer(components);
            pressSpace = new Label();
            skiplabel = new Label();
            skipdescription = new Label();
            BackgroundMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)p1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)p2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pauseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackgroundMediaPlayer).BeginInit();
            SuspendLayout();
            // 
            // movetimer
            // 
            movetimer.Enabled = true;
            movetimer.Interval = 16;
            movetimer.Tick += moveTimerEvent;
            // 
            // generellTimer
            // 
            generellTimer.Enabled = true;
            generellTimer.Interval = 60;
            generellTimer.Tick += generellTimerEvent;
            // 
            // speeduptimer
            // 
            speeduptimer.Enabled = true;
            speeduptimer.Interval = 2000;
            speeduptimer.Tick += speedUpTimerEvent;
            // 
            // p1
            // 
            p1.BackColor = Color.Blue;
            p1.Location = new Point(0, 0);
            p1.Margin = new Padding(2);
            p1.Name = "p1";
            p1.Size = new Size(80, 40);
            p1.TabIndex = 1;
            p1.TabStop = false;
            // 
            // p2
            // 
            p2.AccessibleRole = AccessibleRole.IpAddress;
            p2.BackColor = Color.Blue;
            p2.Location = new Point(0, 0);
            p2.Margin = new Padding(2);
            p2.Name = "p2";
            p2.Size = new Size(80, 40);
            p2.TabIndex = 2;
            p2.TabStop = false;
            // 
            // spawnTimer
            // 
            spawnTimer.Enabled = true;
            spawnTimer.Interval = 400;
            spawnTimer.Tick += spawnTimerEvent;
            // 
            // Spielbeginnen
            // 
            Spielbeginnen.AutoSize = true;
            Spielbeginnen.BackColor = Color.Transparent;
            Spielbeginnen.Location = new Point(0, 0);
            Spielbeginnen.Margin = new Padding(2, 0, 2, 0);
            Spielbeginnen.Name = "Spielbeginnen";
            Spielbeginnen.Size = new Size(371, 20);
            Spielbeginnen.TabIndex = 8;
            Spielbeginnen.Text = "Drücke Leertaste oder Klicke um das Spiel zu beginnen";
            Spielbeginnen.Visible = false;
            // 
            // gameOver
            // 
            gameOver.AutoSize = true;
            gameOver.BackColor = Color.Transparent;
            gameOver.Enabled = false;
            gameOver.Font = new Font("Bernard MT Condensed", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameOver.Location = new Point(0, 0);
            gameOver.Margin = new Padding(2, 0, 2, 0);
            gameOver.Name = "gameOver";
            gameOver.Size = new Size(576, 140);
            gameOver.TabIndex = 9;
            gameOver.Text = "GAME OVER";
            gameOver.Visible = false;
            // 
            // pauseButton
            // 
            pauseButton.BackColor = Color.Transparent;
            pauseButton.Image = (Image)resources.GetObject("pauseButton.Image");
            pauseButton.Location = new Point(0, 0);
            pauseButton.Margin = new Padding(2);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(80, 80);
            pauseButton.SizeMode = PictureBoxSizeMode.Zoom;
            pauseButton.TabIndex = 12;
            pauseButton.TabStop = false;
            pauseButton.Click += pauseButton_Click;
            // 
            // delayTimer
            // 
            delayTimer.Tick += delayTimer_Event;
            // 
            // pressSpace
            // 
            pressSpace.AutoSize = true;
            pressSpace.Location = new Point(68, 143);
            pressSpace.Margin = new Padding(2, 0, 2, 0);
            pressSpace.Name = "pressSpace";
            pressSpace.Size = new Size(207, 20);
            pressSpace.TabIndex = 13;
            pressSpace.Text = "Wechsle 5 mal deine Richtung";
            pressSpace.Visible = false;
            // 
            // skiplabel
            // 
            skiplabel.AutoSize = true;
            skiplabel.Location = new Point(21, 142);
            skiplabel.Margin = new Padding(2, 0, 2, 0);
            skiplabel.Name = "skiplabel";
            skiplabel.Size = new Size(43, 20);
            skiplabel.TabIndex = 14;
            skiplabel.Text = "Enter";
            skiplabel.Click += skiplabel_Click;
            // 
            // skipdescription
            // 
            skipdescription.AutoSize = true;
            skipdescription.Location = new Point(68, 124);
            skipdescription.Margin = new Padding(2, 0, 2, 0);
            skipdescription.Name = "skipdescription";
            skipdescription.Size = new Size(328, 20);
            skipdescription.TabIndex = 15;
            skipdescription.Text = "Drücke Enter oder Leertaste um Weiter zu gehen";
            // 
            // BackgroundMediaPlayer
            // 
            BackgroundMediaPlayer.Enabled = true;
            BackgroundMediaPlayer.Location = new Point(54, 215);
            BackgroundMediaPlayer.Margin = new Padding(2);
            BackgroundMediaPlayer.Name = "BackgroundMediaPlayer";
            BackgroundMediaPlayer.OcxState = (AxHost.State)resources.GetObject("BackgroundMediaPlayer.OcxState");
            BackgroundMediaPlayer.Size = new Size(75, 23);
            BackgroundMediaPlayer.TabIndex = 17;
            // 
            // Tutorial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(222, 195);
            Controls.Add(BackgroundMediaPlayer);
            Controls.Add(skipdescription);
            Controls.Add(skiplabel);
            Controls.Add(pressSpace);
            Controls.Add(pauseButton);
            Controls.Add(gameOver);
            Controls.Add(Spielbeginnen);
            Controls.Add(p2);
            Controls.Add(p1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Tutorial";
            StartPosition = FormStartPosition.Manual;
            Text = "Tutorial";
            WindowState = FormWindowState.Maximized;
            Paint += Tuttry_Paint;
            KeyDown += spaceDown;
            MouseClick += mouseclick;
            ((System.ComponentModel.ISupportInitialize)p1).EndInit();
            ((System.ComponentModel.ISupportInitialize)p2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pauseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackgroundMediaPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer movetimer;
        private System.Windows.Forms.Timer generellTimer;
        private System.Windows.Forms.Timer speeduptimer;
        private PictureBox p1;
        private PictureBox p2;
        private System.Windows.Forms.Timer spawnTimer;
        private Label Spielbeginnen;
        private Label gameOver;
        private PictureBox pauseButton;
        private System.Windows.Forms.Timer delayTimer;
        private Label pressSpace;
        private Label skiplabel;
        private Label skipdescription;
        private AxWMPLib.AxWindowsMediaPlayer BackgroundMediaPlayer;
    }
}
