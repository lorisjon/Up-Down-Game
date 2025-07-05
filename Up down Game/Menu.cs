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
    public partial class Menu : Form
    {

        private int screenW;
        private int screenH;

        private int level;

        private byte closemenu;

        SoundPlayer clicksound = new SoundPlayer(@"./Soundeffects/ui-click-louder.wav");


        public Menu()
        {
            InitializeComponent();


            spielfeldMenuSwitch.Setclosemenu(0);

            level = spielfeldMenuSwitch.level;

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

            this.Size = new Size((int)((screenW / 2.4f) + 0.5), (int)((screenH / 2f) + 0.5));
            this.Location = new Point((int)((screenW / 2f) - (this.Width / 2f) + 0.5), (int)(screenH / 2f - this.Height / 2f + 0.5));


            restartbutton.Font = new Font("Bernard MT Condensed", (int)(this.Height / (800f / 100f) + 0.5));
            restartbutton.Location = new Point((int)(this.Width / 2f - restartbutton.Width / 2f + 0.5), (int)(this.Height / 2f - restartbutton.Height / 2f + 0.5) /*(int)(this.Height / 32f * 11f + 0.5)*/);
            restartbutton.BackColor = Color.FromArgb(255, 43, 112, 160);

            weiterbutton.Font = new Font("Bernard MT Condensed", (int)(this.Height / (800f / 100f) + 0.5));
            weiterbutton.Width = restartbutton.Width;
            weiterbutton.Location = new Point((int)(this.Width / 2f - weiterbutton.Width / 2f + 0.5), 0/*(int)(this.Height / 32f * 2f + 0.5)*/);
            weiterbutton.BackColor = Color.FromArgb(255, 50, 128, 78);

            exitbutton.Font = new Font("Bernard MT Condensed", (int)(this.Height / (800f / 100f) + 0.5));
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

        private void weiterbutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            spielfeldMenuSwitch.Setpausweiter(1);
            this.Close();
        }

        private void restartbutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            spielfeldMenuSwitch.Setrestart(1);
            this.Close();
        }

        private void closeMenuTimer_tick(object sender, EventArgs e)
        {
            closemenu = spielfeldMenuSwitch.closemenu;

            if (closemenu == 1)
            {
                this.Close();
            }
        }

        private void DOWN(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                clicksound.Play();
                spielfeldMenuSwitch.Setpausweiter(1);
                this.Close();
            }
        }
    }
}
