using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Up_down_Game
{
    public partial class TutOverScreen : Form
    {

        private int screenW, screenH;

        private int level;

        private int score;

        private byte close;

        SoundPlayer clicksound = new SoundPlayer(@"./Soundeffects/ui-click-louder.wav");

        public TutOverScreen()
        {
            InitializeComponent();

            level = spielfeldMenuSwitch.level;
            score = spielfeldMenuSwitch.score;

            spielfeldMenuSwitch.Setclosemenu(0);

            switch (level)
            {
                case 1:
                    //this.BackColor = Color.FromArgb(255, 112, 139, 143);
                    this.BackColor = Color.FromArgb(255, 137, 191, 199);
                    break;
                case 2:
                    //this.BackColor = Color.FromArgb(255, 118, 137, 94);
                    this.BackColor = Color.FromArgb(255, 150, 187, 102);
                    break;


                case 3:
                    //this.BackColor = Color.FromArgb(255, 68, 107, 81); 
                    this.BackColor = Color.FromArgb(255, 50, 128, 76);

                    break;

                case 4:
                    //this.BackColor = Color.FromArgb(255, 90, 121, 133); 
                    this.BackColor = Color.FromArgb(255, 93, 156, 180);

                    break;

                case 5:
                    //this.BackColor = Color.FromArgb(255, 164, 118, 97);  
                    this.BackColor = Color.FromArgb(255, 242, 150, 108);
                    break;

                case 6:
                    //this.BackColor = Color.FromArgb(255, 121, 55, 71); 
                    this.BackColor = Color.FromArgb(255, 155, 23, 55);

                    break;

                case 7:
                    //this.BackColor = Color.FromArgb(255, 112, 139, 143);     
                    this.BackColor = Color.FromArgb(255, 137, 191, 199);

                    break;

                case 8:
                    //this.BackColor = Color.FromArgb(255, 68, 107, 81);           
                    this.BackColor = Color.FromArgb(255, 50, 128, 76);
                    break;


                case 9:
                    //this.BackColor = Color.FromArgb(255, 90, 121, 133);     
                    this.BackColor = Color.FromArgb(255, 93, 156, 180);
                    break;

                case 10:
                    // this.BackColor = Color.FromArgb(255, 121, 55, 71);     
                    this.BackColor = Color.FromArgb(255, 155, 23, 55);
                    break;

                default:
                    this.BackColor = Color.FromArgb(255, 137, 191, 199);
                    break;
            }

            this.DoubleBuffered = true;

            this.FormBorderStyle = FormBorderStyle.None;

            screenW = Screen.GetBounds(this).Width;
            screenH = Screen.GetBounds(this).Height;

            this.Size = new Size((int)((screenW / 2.4f) + 0.5), (int)((screenH / 1.6f) + 0.5));
            this.Location = new Point((int)((screenW / 2f) - (this.Width / 2f) + 0.5), (int)(screenH / 2f - this.Height / 2f + 0.5));

            scoreannouncelabel.Text = "Score";
            scoreannouncelabel.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 30f) + 0.5));
            scoreannouncelabel.Location = new Point((int)(this.Width / 2f - scoreannouncelabel.Width / 2f + 0.5), 0/*(int)(this.Height / 32f * 2f + 0.5)*/);

            Scorelabel.Text = score.ToString();
            Scorelabel.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 67.5f) + 0.5));
            Scorelabel.Location = new Point((int)(this.Width / 2f - Scorelabel.Width / 2f + 0.5), scoreannouncelabel.Location.Y + scoreannouncelabel.Height/*(int)(this.Height / 32f * 2f + 0.5)*/);


            replaybutton.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 34f) + 0.5));
            replaybutton.BackColor = Color.FromArgb(255, 43, 112, 160);
            replaybutton.Height += (int)(replaybutton.Height / 2f + 0.5);
            replaybutton.Location = new Point((int)(this.Width / 2f - replaybutton.Width / 2f + 0.5), (int)(Scorelabel.Location.Y + Scorelabel.Height + (replaybutton.Height / 4f) + 0.5));

            mainmenubutton.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 34f) + 0.5));
            mainmenubutton.Width = replaybutton.Width;
            mainmenubutton.BackColor = Color.FromArgb(255, 178, 13, 29);//Color.FromArgb(255, 240, 91, 152);
            mainmenubutton.Height += (int)(mainmenubutton.Height / 2f + 0.5);
            mainmenubutton.Location = new Point((int)(this.Width / 2f - mainmenubutton.Width / 2f + 0.5), this.Height - mainmenubutton.Height/*(int)(this.Height / 32f * 20f + 0.5)*/);

            forrealbutton.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 34f) + 0.5));
            forrealbutton.Width = replaybutton.Width;
            forrealbutton.Location = new Point((int)(this.Width / 2f - forrealbutton.Width / 2f + 0.5), (int)((replaybutton.Location.Y + replaybutton.Height) + ((mainmenubutton.Location.Y - (replaybutton.Location.Y + replaybutton.Height + forrealbutton.Height)) / 4)));
            forrealbutton.Height += (int)(forrealbutton.Height / 2f + 0.5);
            forrealbutton.BackColor = Color.FromArgb(255, 50, 128, 78);

        }

        private void replaybutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            spielfeldMenuSwitch.Setrestart(1);
            this.Close();
        }

        private void forrealbutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            spielfeldMenuSwitch.Setclosetut(1);
            this.Close();
        }

        private void mainmenubutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            spielfeldMenuSwitch.Setclosespiel(1);
            this.Close();
        }

        private void closeTimer_Tick(object sender, EventArgs e)
        {
            close = spielfeldMenuSwitch.closemenu;

            if (close == 1)
            {
                this.Close();
            }
        }
    }

}
