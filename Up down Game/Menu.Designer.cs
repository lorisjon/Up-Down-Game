namespace Up_down_Game
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            weiterbutton = new Button();
            restartbutton = new Button();
            exitbutton = new Button();
            closeMenuTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // weiterbutton
            // 
            weiterbutton.AutoSize = true;
            weiterbutton.Location = new Point(248, 84);
            weiterbutton.Margin = new Padding(2, 2, 2, 2);
            weiterbutton.Name = "weiterbutton";
            weiterbutton.Size = new Size(90, 30);
            weiterbutton.TabIndex = 0;
            weiterbutton.Text = "Weiter";
            weiterbutton.UseVisualStyleBackColor = true;
            weiterbutton.Click += weiterbutton_Click;
            weiterbutton.KeyDown += DOWN;
            // 
            // restartbutton
            // 
            restartbutton.AutoSize = true;
            restartbutton.Location = new Point(241, 150);
            restartbutton.Margin = new Padding(2, 2, 2, 2);
            restartbutton.Name = "restartbutton";
            restartbutton.Size = new Size(90, 30);
            restartbutton.TabIndex = 1;
            restartbutton.Text = "Restart";
            restartbutton.UseVisualStyleBackColor = true;
            restartbutton.Click += restartbutton_Click;
            // 
            // exitbutton
            // 
            exitbutton.AutoSize = true;
            exitbutton.Location = new Point(278, 212);
            exitbutton.Margin = new Padding(2, 2, 2, 2);
            exitbutton.Name = "exitbutton";
            exitbutton.Size = new Size(90, 30);
            exitbutton.TabIndex = 2;
            exitbutton.Text = "Menu";
            exitbutton.UseVisualStyleBackColor = true;
            exitbutton.Click += quitbutton_Click;
            // 
            // closeMenuTimer
            // 
            closeMenuTimer.Enabled = true;
            closeMenuTimer.Interval = 10;
            closeMenuTimer.Tick += closeMenuTimer_tick;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 360);
            Controls.Add(exitbutton);
            Controls.Add(restartbutton);
            Controls.Add(weiterbutton);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button weiterbutton;
        private Button restartbutton;
        private Button exitbutton;
        private System.Windows.Forms.Timer closeMenuTimer;
    }
}