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

namespace Up_down_Game
{
    public partial class GameOverScreen : Form
    {

        private int screenW, screenH;

        private int level;

        private int score;

        private int Highscore;

        SoundPlayer clicksound = new SoundPlayer(@"./Soundeffects/ui-click-louder.wav");

        public GameOverScreen()
        {
            InitializeComponent();

            level = spielfeldMenuSwitch.level;
            score = spielfeldMenuSwitch.score;

            switch (level)
            {
                case 1:
                    this.BackColor = Color.FromArgb(255, 137, 191, 199);
                    break;
                case 2:
                    this.BackColor = Color.FromArgb(255, 150, 187, 102);
                    break;


                case 3:
                    this.BackColor = Color.FromArgb(255, 50, 128, 76);

                    break;

                case 4:
                    this.BackColor = Color.FromArgb(255, 93, 156, 180);

                    break;

                case 5:
                    this.BackColor = Color.FromArgb(255, 242, 150, 108);
                    break;

                case 6:
                    this.BackColor = Color.FromArgb(255, 155, 23, 55);

                    break;

                case 7:
                    this.BackColor = Color.FromArgb(255, 137, 191, 199);

                    break;

                case 8:
                    this.BackColor = Color.FromArgb(255, 50, 128, 76);
                    break;


                case 9:
                    this.BackColor = Color.FromArgb(255, 93, 156, 180);
                    break;

                case 10:
                    this.BackColor = Color.FromArgb(255, 155, 23, 55);
                    break;

                default:
                    break;
            }

            this.DoubleBuffered = true;

            this.FormBorderStyle = FormBorderStyle.None;

            screenW = Screen.GetBounds(this).Width;
            screenH = Screen.GetBounds(this).Height;

            this.Size = new Size((int)((screenW / 2.4f) + 0.5), (int)((screenH / 1.8f) + 0.5));
            this.Location = new Point((int)((screenW / 2f) - (this.Width / 2f) + 0.5), (int)(screenH / 2f - this.Height / 2f + 0.5));

            scoreanouncelabel.Text = "Score";
            scoreanouncelabel.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 30f) + 0.5));
            scoreanouncelabel.Location = new Point((int)(this.Width / 2f - scoreanouncelabel.Width / 2f + 0.5), 0/*(int)(this.Height / 32f * 2f + 0.5)*/);

            Scorelabel.Text = score.ToString();
            Scorelabel.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 67.5f) + 0.5));
            Scorelabel.Location = new Point((int)(this.Width / 2f - Scorelabel.Width / 2f + 0.5), scoreanouncelabel.Location.Y + scoreanouncelabel.Height/*(int)(this.Height / 32f * 2f + 0.5)*/);

            Highscore = Up_down_Game.Properties.Settings.Default.Highscore;


            Highscorelabel.Text = "Best: " + Highscore.ToString();
            Highscorelabel.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 22.5f) + 0.5));
            Highscorelabel.Location = new Point((int)(this.Width / 2f - Highscorelabel.Width / 2f + 0.5), (int)(Scorelabel.Location.Y + Scorelabel.Height + Highscorelabel.Height / 2f + 0.5));//(int)(Scorelabel.Location.Y + Scorelabel.Height /*+ /*(Highscorelabel.Height / 2)*/));
            //Highscorelabel.ForeColor = Color.FromArgb(255, 205, 205, 200);
            Highscorelabel.ForeColor = Color.FromArgb(255, 94, 94, 93);


            restartbutton.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 45f) + 0.5));
            restartbutton.Location = new Point((int)(this.Width / 2f - restartbutton.Width / 2f + 0.5), (int)(Highscorelabel.Location.Y + Highscorelabel.Height + restartbutton.Height / 4f + 0.5)/*(int)(quitbutton.Location.Y - restartbutton.Height * 1.5f + 0.5)/*(int)(this.Height / 2f - restartbutton.Height / 2f + 0.5) /*(int)(this.Height / 32f * 11f + 0.5)*/);
            //restartbutton.BackColor = Color.FromArgb(255, 177, 207, 108);//Color.FromArgb(255, 240, 195, 91);
            restartbutton.BackColor = Color.FromArgb(255, 50, 128, 78);

            exitbutton.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 45f) + 0.5));
            exitbutton.Width = restartbutton.Width;
            exitbutton.Location = new Point((int)(this.Width / 2f - exitbutton.Width / 2f + 0.5), this.Height - exitbutton.Height/*(int)(this.Height / 32f * 20f + 0.5)*/);
            exitbutton.BackColor = Color.FromArgb(255, 178, 13, 29);//Color.FromArgb(255, 240, 91, 152);

        }

        private void quitbutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            spielfeldMenuSwitch.Setclosespiel(1);
            this.Close();
        }

        private void restartbutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            spielfeldMenuSwitch.Setrestart(1);
            this.Close();
        }
    }
}
