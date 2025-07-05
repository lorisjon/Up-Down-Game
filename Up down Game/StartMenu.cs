using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Up_down_game_5;
using static System.Windows.Forms.DataFormats;

namespace Up_down_Game
{
    public partial class StartMenu : Form
    {
        private int screenW;
        private int screenH;

        //SoundPlayer clicksound = new SoundPlayer(@"./Soundeffects/Click-Sound.wav");
        SoundPlayer clicksound = new SoundPlayer(@"./Soundeffects/ui-click-louder.wav");

        public StartMenu()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.FormBorderStyle = FormBorderStyle.None;

            screenW = Screen.GetBounds(this).Width;
            screenH = Screen.GetBounds(this).Height;

            this.BackColor = Color.FromArgb(255, 203, 216, 224);/*Color.FromArgb(255, 254, 243, 214);*/


            this.Size = new Size((int)((screenW / 2.4f) + 0.5), (int)((screenH / 12f * 7f) + 0.5));
            this.Location = new Point((int)((screenW / 2f) - (this.Width / 2f) + 0.5), (int)(screenH / 2f - this.Height / 2f + 0.5));


            startgamebutton.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 45f) + 0.5));
            startgamebutton.Location = new Point((int)(this.Width / 2f - startgamebutton.Width / 2f + 0.5), (int)(startgamebutton.Height / 2f + 0.5)/*(int)(this.Height / 32f * 2f + 0.5)*/);
            startgamebutton.BackColor = Color.FromArgb(255, 50, 128, 78);


            tutorialbutton.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 45f) + 0.5));
            tutorialbutton.Width = startgamebutton.Width;
            tutorialbutton.Location = new Point((int)(this.Width / 2f - tutorialbutton.Width / 2f + 0.5), (int)(this.Height / 2f - tutorialbutton.Height / 2f + 0.5)/*(int)(this.Height / 32f * 11f + 0.5)*/);
            //tutorialbutton.BackColor = /*Color.FromArgb(255, 165, 194, 222);*//*Color.FromArgb(255, 43, 112, 160);*/Color.FromArgb(255, 177, 207, 108);
            tutorialbutton.BackColor = Color.FromArgb(255, 43, 112, 160);

            quitbutton.Font = new Font("Bernard MT Condensed", (int)(screenH / (800f / 45f) + 0.5));
            quitbutton.Width = startgamebutton.Width;
            quitbutton.Location = new Point((int)(this.Width / 2f - quitbutton.Width / 2f + 0.5), (int)(this.Height - quitbutton.Height * 1.5f + 0.5) /*(int)(this.Height / 32f * 20f + 0.5)*/);
            quitbutton.BackColor = /*Color.FromArgb(255, 234, 97, 9);*/Color.FromArgb(255, 178, 13, 29);


        }
        class MenuProgramm
        {
            /// <summary>
            /// Der Haupteinstiegspunkt für die Anwendung.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                StartMenu menuForm = new StartMenu();
                menuForm.Show();
                Application.Run();
                //Application.Run(new MenuForm());
            }
        }


        private void startGame_Click(object sender, EventArgs e)
        {
            /*opacity = 1;
            spielfeldMenuSwitch.SetOpacity(opacity);
            spielfeldMenuSwitch.Setpausweiter(1);*/
            clicksound.Play();
            Spielfeld spielfeld = new Spielfeld();
            spielfeld.Show();
            this.Hide();
        }

        private void quitbutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            Application.Exit();
        }

        private void tutorialbutton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            Tutorial tutorial = new Tutorial();
            tutorial.Show();
            this.Hide();
        }
    }
}
