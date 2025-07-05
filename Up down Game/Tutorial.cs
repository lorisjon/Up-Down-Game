using System.Diagnostics;
using System.Drawing;
using System.Security.Policy;
using System;
using System.Windows.Forms;
//using Presentation.Framework
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static Up_down_game_5.Tutorial;
using Microsoft.VisualBasic;
using System.Media;
using Up_down_Game;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;


namespace Up_down_game_5
{
    public partial class Tutorial : Form
    {
        //movement für die Spielfigur
        bool moveUp, moveDown;

        //booleans damit einige aktionen nur einmal ausgeführt werden
        //un beim restart werden die meisten dieser werte wieder auf true gestzt
        bool nureinmal = true;
        bool nureinmal2 = true;
        bool nureinmal3 = true;
        bool nureinmal4 = true;
        bool nureinmal5 = true;
        bool nureinmal6 = true;
        bool nureinmal7 = true;
        bool nureinmal8 = true;
        bool nureinmal9 = true;

        //boolean ob das Spiel gestarted ist oder nicht
        bool spielgestarted = false;

        //zum checken ob die Platformen schon berührt wurden / ob sie noch punkte geben können oder nicht
        bool p1active = true;
        bool p2active = true;

        //booleans für die Pause funktion und für die anweisungstext funktion
        bool Pause = false;
        bool Pause1 = false;
        bool ufä, abä;
        bool Hindernissmove = true;
        bool vorspielstart = true;
        bool Hindernisdazu = false;
        bool countdown = false;
        bool skip = false;

        Rectangle playerrecteck;

        int speedSF = 0; // Speed Spiel Figur
        int speedH = 0; // Speed Hinderniss


        int colorChangeTime = 8;
        int level = 0;

        Random rand = new Random();

        int x, y;
        int spawnTime = 4;
        int[] sizes2 = { 1, 2, 3 };
        int[] linksrechts = { 0, 1 };

        int hindernissCounter = 0;
        int spawnTimeCounter = 0;
        int scoreCounter = 0;
        int speedUpCounter = 0;
        int delayCounter = 0;
        int spacecounter = 0;
        int delaycounter = 0;
        int messagenr = 0;

        List<Hindernis> hindernisList = new List<Hindernis>();

        TextBox levelText;
        TextBox ScoreGross;

        private int screenW;
        private int screenH;
        private int pauseweiter;
        private int menurestartbutton = 0;
        private byte closeSpiel = 0;
        private byte closeTut = 0;

        SoundPlayer oversound = new SoundPlayer(@"./Soundeffects/short-beep-tone-louder.wav");
        SoundPlayer clicksound = new SoundPlayer(@"./Soundeffects/ui-click-louder.wav");
        SoundPlayer bloop = new SoundPlayer(@"./Soundeffects/bloop-2.wav");
        SoundPlayer swipeDown = new SoundPlayer(@"./Soundeffects/swing-whoosh-5-quiet.wav");

        /*für speedupTimerEvent und generellTimerEvent*/
        private int speedrech1;
        private int speedrech2;
        private int speedrech3;
        private int speedrech4;
        private int speedrech5;
        private int speedrech6;
        private int speedrech7;
        private int speedrech8;
        private int speedrech9;
        private int speedrech10;
        private int speedrech11;
        private int speedrech12;
        private int speedrech13;
        private int speedrech14;
        private int speedrech15;
        private int speedrech16;
        private int speedrech17;
        private int speedrech18;
        private int speedrech19;
        private int speedrech20;

        public Tutorial()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            screenW = Screen.GetBounds(this).Width;
            screenH = Screen.GetBounds(this).Height;

            this.Size = new Size(screenW, screenH);
            playerrecteck = new Rectangle((int)(screenW / 2f - screenH / 40f + 0.5), (int)(screenH / 4f * 3f - screenH / 20f + 0.5), (int)(screenH / 20f + 0.5), (int)(screenH / 20f + 0.5));
            levelText = new TextBox(new Rectangle((int)(screenW / 2f - ((screenW / (1920f / 256f)) / 2f) + 0.5f), (int)(screenH / 15f + 0.5f), (int)(screenW / (1920f / 256f) + 0.5), (int)(screenH / (1200f / 129f) + 0.5)), "Level 0", "Agency FB", (int)(screenW / (1920f / 54f) + 0.5), Color.Transparent, Color.FromArgb(255, 139, 139, 138));
            ScoreGross = new TextBox(new Rectangle((int)(screenW / 2f - ((screenW / (1920f / 379f/*568.5f*/) + 0.5) / 2f) + 0.5), (int)(screenH / 2f - ((screenH / (1200f / 307f/*460.5*/) + 0.5) / 2f) + 0.5), (int)(screenW / (1920f / 379f/*568.5f*/) + 0.5), (int)(screenH / (1200f / 307f /*460.5f*/) + 0.5)), "0", "Segoe UI", (int)(screenH / (1200f / 166f/*249f*/) + 0.5), Color.Transparent, Color.FromArgb(255, 139, 139, 138));



            sizes2[0] = (int)(screenH / (1200f / 70f) + 0.5);
            sizes2[1] = (int)(screenH / (1200f / 40f) + 0.5);
            sizes2[2] = (int)(screenH / (1200f / 90f) + 0.5);

            linksrechts[1] = screenW;
            
            p1.Size = new Size((int)(screenW / (1920f / 477f) + 0.5), (int)(screenH / (1200f / 12f) + 0.5));
            p1.Location = new Point((int)(screenW / 2f - p1.Width / 2f + 0.5), (int)(screenH / 40f + 0.5));
            p1.BackColor = Color.FromArgb(255, 43, 112, 160);

            pauseButton.Size = new Size((int)(screenH / (1200f / 100f) + 0.5), (int)(screenH / (1200f / 100f) + 0.5));
            pauseButton.Location = new Point(p1.Location.X - p1.Width, (int)(screenH / 100f + 0.5));


            p2.Size = new Size((int)(screenW / (1920f / 477f) + 0.5), (int)(screenH / (1200f / 12) + 0.5));
            p2.Location = new Point((int)(screenW / 2f - p2.Width / 2f + 0.5), (int)(screenH / 40f * 36f - p2.Height + 0.5));
            p2.BackColor = Color.FromArgb(255, 43, 112, 160);



            Spielbeginnen.Font = new Font("Bernard MT Condensed", (int)(screenH / (1200f / 33f) + 0.5) /*(int)(Spielbeginnen.Width / (959f / 22f))*/, FontStyle.Regular);
            Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));

            skiplabel.Font = new Font("Bernard MT Condensed", (int)(screenH / (1200f / 33f) + 0.5) /*(int)(Spielbeginnen.Width / (959f / 22f))*/, FontStyle.Regular);
            skiplabel.Location = new Point((int)(p2.Location.X + p2.Width * 1.5 - skiplabel.Width / 2), (int)(p2.Location.Y - skiplabel.Height * 2 - skiplabel.Height * 0.5 + 0.5));
            skiplabel.Visible = false;

            skipdescription.Font = new Font("segoe", (int)(screenH / (1200f / 23f) + 0.5), FontStyle.Regular);
            skipdescription.Location = new Point((int)((skiplabel.Location.X + skiplabel.Width / 2f) - skipdescription.Width / 2f + 0.5), (int)(skiplabel.Location.Y - skiplabel.Height / 2f - skipdescription.Height + 0.5));
            skipdescription.Visible = false;

            gameOver.Font = new Font("Bernard MT Condensed", (int)(screenH / (1200f / 108f) + 0.5));
            gameOver.Location = new Point((int)(screenW / 2f - gameOver.Width / 2f + 0.5), (int)(screenH / 5f + 0.5));

            BackgroundMediaPlayer.URL = @"./Soundeffects/Backgroundmusicwhole.mp3";
            BackgroundMediaPlayer.Ctlcontrols.stop();
            BackgroundMediaPlayer.Visible = false;


            //berechnungen für generellTimerEvent
            speedrech1 = (int)(screenH / (1200f / 12.8f) + 0.5);
            speedrech2 = (int)(screenW / (1200f / 3.2f) + 0.5);
            speedrech3 = (int)(screenH / (800f / 16) + 0.5);
            speedrech4 = (int)(screenH / (800f / 8) + 0.5);
            speedrech5 = (int)(screenH / (800f / 19.2f) + 0.5);
            speedrech6 = (int)(screenH / (800f / 9.6f) + 0.5);
            speedrech7 = (int)(screenH / (800f / 24f) + 0.5);
            speedrech8 = (int)(screenH / (800f / 16f) + 0.5);
            speedrech9 = (int)(screenH / (800f / 32f) + 0.5);
            speedrech10 = (int)(screenH / (800f / 24f) + 0.5);
            speedrech11 = (int)(screenH / (800f / 40f) + 0.5);
            speedrech12 = (int)(screenH / (800f / 32f) + 0.5);
            speedrech13 = (int)(screenH / (800f / 48f) + 0.5);
            speedrech14 = (int)(screenH / (800f / 40f) + 0.5);
            speedrech15 = (int)(screenH / (800f / 56f) + 0.5);
            speedrech16 = (int)(screenH / (800f / 48f) + 0.5);
            speedrech17 = (int)(screenH / (800f / 64f) + 0.5);
            speedrech18 = (int)(screenH / (800f / 56f) + 0.5);
            speedrech19 = (int)(screenH / (800f / 72f) + 0.5);
            speedrech20 = (int)(screenH / (800f / 64f) + 0.5);
        }



        public void MakeHinderniss()
        {
            int gösi = sizes2[rand.Next(0, sizes2.Length)];

            x = linksrechts[rand.Next(0, linksrechts.Length)];
            y = rand.Next(p1.Location.Y, p2.Location.Y - gösi);

            int richtig;
            if (x == 0)
            {
                richtig = 1;
            }
            else
            {
                richtig = -1;
            }

            Hindernis Hindernis2;


            if (level >= 4)
            {
                Hindernis2 = new Hindernis(new Rectangle(x, y, gösi, gösi), x, y, Color.Black, richtig, speedH);
            }

            else
            {
                Hindernis2 = new Hindernis(new Rectangle(x, y, gösi, gösi), x, y, /*Color.DarkRed*/Color.FromArgb(255, 178, 13, 29), richtig, speedH);
            }
            hindernisList.Add(Hindernis2);




            if (hindernissCounter > 5)
            {
                foreach (Hindernis h in hindernisList)
                {
                    hindernisList.Remove(h);
                    break;
                }
            }
            else
            {
                hindernissCounter++;
            }

        }


        private void moveTimerEvent(object sender, EventArgs e)
        {
            Invalidate();
            if (moveUp == true && playerrecteck.Y > p1.Location.Y + p1.Height / 2 && spielgestarted == true)
            {
                playerrecteck.Y -= speedSF;
            }

            if (moveDown == true && playerrecteck.Y < p2.Location.Y - playerrecteck.Height + p2.Height / 2 && spielgestarted == true)
            {
                playerrecteck.Y += speedSF;
            }

            if (playerrecteck.Y <= p1.Location.Y + p1.Height / 2 && spielgestarted == true)
            {
                bloop.Play();
                moveUp = false;
                moveDown = true;
                if (p1active)
                {
                    scoreCounter++;
                    p1active = false;
                    p2active = true;

                    p1.BackColor = Color.FromArgb(255, 177, 207, 108);
                    p2.BackColor = Color.FromArgb(255, 43, 112, 160);
                }
            }


            if (playerrecteck.Y >= p2.Location.Y - playerrecteck.Height + p2.Height / 2 && spielgestarted == true)
            {
                bloop.Play();
                moveUp = true;
                moveDown = false;
                if (p2active)
                {
                    scoreCounter++;
                    p1active = true;
                    p2active = false;
                    p2.BackColor = Color.FromArgb(255, 177, 207, 108);
                    p1.BackColor = Color.FromArgb(255, 43, 112, 160);
                }
            }

            foreach (Hindernis hindernis in hindernisList)
            {
                if (playerrecteck.IntersectsWith(hindernis.bounds) && nureinmal2 == true)
                {
                    spielgestarted = false;
                    Hindernissmove = false;
                    moveUp = false;
                    moveDown = false;
                    nureinmal2 = false;
                    gameOver.Enabled = true;
                    gameOver.Visible = true;
                    oversound.Play();
                }
            }

            if (gameOver.Enabled == true && gameOver.Visible == true)
            {
                Hindernissmove = false;
            }


            foreach (Hindernis hindernis in hindernisList)
            {
                if (Hindernissmove == true)
                {
                    hindernis.move();
                }
            }

        }



        public class Hindernis
        {
            int x, y;
            Color farb;
            int leftright;
            int speed;
            public Rectangle bounds;
            public Hindernis(Rectangle grössip, int xp, int yp, Color farbp, int leftright, int speed)
            {
                bounds = grössip;
                x = xp;
                y = yp;
                farb = farbp;
                this.leftright = leftright;
                this.speed = speed;
            }

            public void draw(Graphics g)
            {
                g.FillRectangle(new SolidBrush(farb), bounds);
            }
            public void move()
            {
                bounds.X += speed * leftright;
            }
        }

        private void mouseclick(object sender, MouseEventArgs e)
        {
            if (moveUp && Pause == false)
            {
                swipeDown.Play();
                moveUp = false;
                moveDown = true;
                spacecounter++;
            }


            else if (moveDown && Pause == false)
            {
                swipeDown.Play();
                moveUp = true;
                moveDown = false;
                spacecounter++;
            }

            else if (moveDown == false && moveUp == false && Pause == false)
            {
                Spielbeginnen.Visible = false;
                spacecounter++;
                spielgestarted = true;
                vorspielstart = false;
                moveUp = true;
                moveDown = false;
                BackgroundMediaPlayer.settings.volume = 40;
                BackgroundMediaPlayer.Ctlcontrols.play();
            }

        }


        //handlet die geschwindigkeitserhöhung der Hindernisse und der Spielfigur 
        private void speedUpTimerEvent(object sender, EventArgs e)
        {
            switch (level)
            {
                case 0:
                    break;

                case 1:
                    speedSF = speedrech1;
                    speedH = speedrech2;
                    break;
                case 2:
                    if (speedSF < speedrech3)
                    {
                        if (speedH < speedrech4)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;


                case 3:
                    if (speedSF < speedrech5)
                    {
                        if (speedH < speedrech6)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;

                case 4:
                    if (speedSF < speedrech7)
                    {
                        if (speedH < speedrech8)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;

                case 5:
                    if (speedSF < speedrech9)
                    {
                        if (speedH < speedrech10)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;

                case 6:
                    if (speedSF < speedrech11)
                    {
                        if (speedH < speedrech12)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;

                case 7:
                    if (speedSF < speedrech13)
                    {
                        if (speedH < speedrech14)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;

                case 8:
                    if (speedSF < speedrech15)
                    {
                        if (speedH < speedrech16)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;


                case 9:
                    if (speedSF < speedrech17)
                    {
                        if (speedH < speedrech18)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;

                case 10:
                    if (speedSF < speedrech19)
                    {
                        if (speedH < speedrech20)
                        {
                            speedH++;
                        }
                        speedUpCounter++;
                        if (speedUpCounter % 2 == 0)
                        {
                            speedSF++;
                        }
                    }
                    break;

                default:
                    break;
            }

        }


        private void spaceDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (moveUp && Pause == false /* && spacefix == true */)
                {
                    swipeDown.Play();
                    moveUp = false;
                    moveDown = true;
                    spacecounter++;
                }


                else if (moveDown && Pause == false /* && spacefix == true */)
                {
                    swipeDown.Play();
                    moveUp = true;
                    moveDown = false;
                    spacecounter++;
                }

                else if (moveDown == false && moveUp == false && Pause == false)
                {
                    Spielbeginnen.Visible = false;
                    spacecounter++;
                    spielgestarted = true;
                    vorspielstart = false;
                    moveUp = true;
                    moveDown = false;
                    BackgroundMediaPlayer.settings.volume = 40;
                    BackgroundMediaPlayer.Ctlcontrols.play();
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                pause();
                spielfeldMenuSwitch.Setpausweiter(0);
                Menu menu = new Menu();
                menu.TopMost = true;
                menu.Show();
            }

            if (e.KeyCode == Keys.Enter || (e.KeyCode == Keys.Space && messagenr <= 9))
            {
                if (skip && Pause1 == false)
                {
                    delaycounter = 0;
                }
            }
        }

        private void generellTimerEvent(object sender, EventArgs e)
        {
            if (moveUp == false && moveDown == false && nureinmal == true)
            {
                nureinmal = false;
                Spielbeginnen.Visible = true;
            }

            switch (spacecounter)
            {
                case 1:
                    if (nureinmal5 == true)
                    {
                        messagenr = 1;
                        Pause = true;
                        delaycounter = 7;
                        delayTimer.Start();
                        nureinmal5 = false;
                    }
                    break;
                case 5:
                    if (nureinmal9 == true)
                    {
                        pressSpace.Visible = false;
                        messagenr = 12;
                        nureinmal9 = false;
                        delaycounter = 10;
                        delayTimer.Start();
                    }
                    break;
            }

            switch (scoreCounter)
            {
                case 1:
                    if (nureinmal6 == true)
                    {
                        nureinmal6 = false;
                        Spielbeginnen.Text = "Berührst du eine Blaue platte wird diese Grau und gibt keine Punkte mehr";
                        Spielbeginnen.Location = new Point((int)(screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        Pause = true;
                        pause();
                        messagenr = 3;
                        delaycounter = 120;
                        delayTimer.Start();
                    }
                    break;

                case 2:
                    if (nureinmal7 == true)
                    {
                        nureinmal7 = false;
                        Spielbeginnen.Text = "Jetzt wird diese Platte Grau und die andere wieder Blau";
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        Pause = true;
                        pause();
                        messagenr = 6;
                        delaycounter = 120;
                        delayTimer.Start();
                    }
                    break;

                case 6:
                    if (nureinmal8 == true)
                    {
                        nureinmal8 = false;
                        delaycounter = 5;
                        delayTimer.Start();
                        messagenr = 9;
                    }
                    break;
            }

            if (delaycounter <= 0)
            {
                switch (messagenr)
                {
                    case 0:
                        break;
                    case 1:
                        Spielbeginnen.Text = "Berühre die Blauen Platten um punkte zu erzielen";
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        messagenr = 2;
                        delaycounter = 120;
                        Pause = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        pause();
                        break;
                    case 2:
                        delayTimer.Stop();
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        weiter();
                        Spielbeginnen.Visible = false;
                        break;

                    case 3:
                        weiter();
                        Spielbeginnen.Visible = false;
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        messagenr = 4;
                        delaycounter = 10;
                        break;

                    case 4:
                        Spielbeginnen.Text = "Nun musst du die Andere Platte berühren";
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        Pause = true;
                        pause();
                        messagenr = 5;
                        delaycounter = 120;
                        break;

                    case 5:
                        delayTimer.Stop();
                        weiter();
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        Spielbeginnen.Visible = false;
                        break;

                    case 6:
                        weiter();
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        Spielbeginnen.Visible = false;
                        messagenr = 7;
                        delaycounter = 20;
                        break;

                    case 7:
                        Spielbeginnen.Text = "und So erzielst du Punkte";
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        messagenr = 8;
                        delaycounter = 50;
                        break;

                    case 8:
                        Spielbeginnen.Visible = false;
                        delayTimer.Stop();
                        break;

                    case 9:
                        Spielbeginnen.Text = "mit der Leertaste oder durch ein Mausklick kannst du deine Richtung ändern";
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        Pause = true;
                        pause();
                        messagenr = 10;
                        delaycounter = 120;
                        break;

                    case 10:
                        Pause = false;
                        weiter();
                        Spielbeginnen.Visible = false;
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        messagenr = 11;
                        delaycounter = 10;
                        break;

                    case 11:
                        pressSpace.Font = new Font("Bernard MT Condensed", (int)(screenH / (1200f / 33f) + 0.5) /*(int)(Spielbeginnen.Width / (959f / 22f))*/, FontStyle.Regular);
                        pressSpace.ForeColor = Color.FromArgb(255, 234, 97, 9);
                        pressSpace.Location = new Point(Spielbeginnen.Location.X + Spielbeginnen.Width - pressSpace.Width / 2, (int)(screenH / 2f));
                        pressSpace.Visible = true;
                        delayTimer.Stop();
                        break;

                    case 12:
                        Pause = true;
                        pause();
                        Spielbeginnen.Text = "Jetzt kommen noch Hindernisse dazu";
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Text = "Drücke Enter um Weiter zu gehen";
                        skipdescription.Location = new Point((int)((skiplabel.Location.X + skiplabel.Width / 2f) - skipdescription.Width / 2f + 0.5), (int)(skiplabel.Location.Y - skiplabel.Height / 2f - skipdescription.Height + 0.5));
                        skipdescription.Visible = true;
                        messagenr = 13;
                        delaycounter = 120;
                        break;

                    case 13:
                        Pause = false;
                        weiter();
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        Hindernisdazu = true;
                        Spielbeginnen.Visible = false;
                        delaycounter = 20;
                        messagenr = 14;
                        break;

                    case 14:
                        Pause = true;
                        pause();
                        Spielbeginnen.Text = "Wechsle deine Richtung um den Hindernissen zu entkommen";
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        messagenr = 15;
                        delaycounter = 120;
                        break;

                    case 15:
                        Pause = false;
                        weiter();
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        Spielbeginnen.Visible = false;
                        delaycounter = 25;
                        messagenr = 16;
                        break;

                    case 16:
                        Pause = true;
                        pause();
                        Spielbeginnen.Text = "Berührst du ein Hindernis Stirbst du";
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        messagenr = 17;
                        delaycounter = 120;
                        break;

                    case 17:
                        Pause = false;
                        weiter();
                        Spielbeginnen.Visible = false;
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        delaycounter = 25;
                        messagenr = 18;
                        break;

                    case 18:
                        Pause = true;
                        pause();
                        Spielbeginnen.Text = "Mit der Esc kommst du in's Spielmenu";
                        Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        delaycounter = 120;
                        messagenr = 19;
                        break;

                    case 19:
                        Pause = false;
                        weiter();
                        Spielbeginnen.Visible = false;
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        delaycounter = 60;
                        messagenr = 20;
                        break;

                    case 20:
                        Pause = true;
                        pause();
                        Spielbeginnen.Text = "Ende Tutorial, du kannst jetzt weiter Spielen bis du stirbst";
                        Spielbeginnen.Location = new Point((int)(screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
                        Spielbeginnen.Visible = true;
                        skip = true;
                        skiplabel.Visible = true;
                        skipdescription.Visible = true;
                        delaycounter = 60;
                        messagenr = 21;
                        break;

                    case 21:
                        Pause = false;
                        weiter();
                        Spielbeginnen.Visible = false;
                        skip = false;
                        skiplabel.Visible = false;
                        skipdescription.Visible = false;
                        delayTimer.Stop();
                        break;

                }
            }

            if (p1.BackColor == Color.FromArgb(255, 177, 207, 108) || p2.BackColor == Color.FromArgb(255, 177, 207, 108))
            {
                colorChangeTime--;
            }


            if (colorChangeTime <= 0)
            {
                colorChangeTime = 8;
                if (p1.BackColor == Color.FromArgb(255, 177, 207, 108))
                {
                    //p1.BackColor = Color.SlateGray;
                    p1.BackColor = Color.FromArgb(255, 94, 94, 93);
                    //p1.BackColor = Color.FromArgb(255, 139, 139, 138);
                }

                if (p2.BackColor == Color.FromArgb(255, 177, 207, 108))
                {
                    //p2.BackColor = Color.SlateGray;
                    p2.BackColor = Color.FromArgb(255, 94, 94, 93);
                    //p2.BackColor = Color.FromArgb(255, 139, 139, 138);
                }
            }


            ScoreGross.ChangeText("" + scoreCounter.ToString());


            if (scoreCounter < 5)
            {
                level = 1;
                spielfeldMenuSwitch.Setlevel(level);
            }

            if (scoreCounter > 4 && scoreCounter < 15)
            {
                level = 2;
                spielfeldMenuSwitch.Setlevel(level);
            }

            if (scoreCounter > 14 && scoreCounter < 25)
            {
                level = 3;
                spielfeldMenuSwitch.Setlevel(level);
            }


            if (scoreCounter > 24 && scoreCounter < 35)
            {
                level = 4;
                spielfeldMenuSwitch.Setlevel(level);
            }

            if (scoreCounter > 34 && scoreCounter < 45)
            {
                level = 5;
                spielfeldMenuSwitch.Setlevel(level);
            }

            if (scoreCounter > 44 && scoreCounter < 55)
            {
                level = 6;
                spielfeldMenuSwitch.Setlevel(level);
            }

            if (scoreCounter > 54 && scoreCounter < 65)
            {
                level = 7;
                spielfeldMenuSwitch.Setlevel(level);
            }

            if (scoreCounter > 64 && scoreCounter < 75)
            {
                level = 8;
                spielfeldMenuSwitch.Setlevel(level);
            }

            if (scoreCounter > 74 && scoreCounter < 85)
            {
                level = 9;
                spielfeldMenuSwitch.Setlevel(level);
            }

            if (scoreCounter > 84)
            {
                level = 10;
                spielfeldMenuSwitch.Setlevel(level);
            }


            levelText.ChangeText("Level " + level.ToString());


            switch (level)
            {
                case 1:
                    //this.BackColor = Color.FromArgb(255, 112, 139, 143);
                    this.BackColor = Color.FromArgb(255, 137, 191, 199);
                    speedSF = (int)(screenH / (1200f / 12.8f /*8f*/) + 0.5);
                    speedH = (int)(screenW / (1200f / 3.2f /*2f*/) + 0.5);
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
                    break;
            }




            pauseweiter = spielfeldMenuSwitch.pausweiter;

            if (pauseweiter == 1)
            {
                pauseweiter = 0;
                spielfeldMenuSwitch.Setpausweiter(0);
                weiter();
            }

            menurestartbutton = spielfeldMenuSwitch.restart;

            if (menurestartbutton == 1)
            {
                menurestartbutton = 0;
                weiter();
                gameOver.Visible = false;
                gameOver.Enabled = false;
                Spielbeginnen.Visible = false;
                restart();
            }

            closeSpiel = spielfeldMenuSwitch.closespiel;

            if (closeSpiel == 1)
            {
                closeSpiel = 0;
                spielfeldMenuSwitch.Setclosespiel(0);
                spielfeldMenuSwitch.Setclosemenu(1);
                if (gameOver.Visible)
                {
                    StartMenu startMenu = new StartMenu();
                    startMenu.Show();
                    this.Close();
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("willst du dass Tutorial wirklich verlassen?", "Exit? ReAlY?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        StartMenu startMenu = new StartMenu();
                        startMenu.Show();
                        this.Close();
                        clicksound.Play();
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        //weiter1();
                        weiter();
                        clicksound.Play();
                    }
                }

            }

            closeTut = spielfeldMenuSwitch.closetut;

            if (closeTut == 1)
            {
                spielfeldMenuSwitch.Setclosemenu(1);
                closeTut = 0;
                spielfeldMenuSwitch.Setclosetut(0);
                Spielfeld spielfeld = new Spielfeld();
                spielfeld.Show();
                this.Close();

            }

        }


        public void restart()
        {
            level = 0;
            moveUp = false;
            moveDown = false;
            spielgestarted = false;
            spawnTimeCounter = 0;
            scoreCounter = 0;
            speedUpCounter = 0;
            hindernissCounter = 0;
            speedSF = 0;
            speedH = 0;
            p1active = true;
            p2active = true;
            p1.BackColor = Color.FromArgb(255, 43, 112, 160);
            p2.BackColor = Color.FromArgb(255, 43, 112, 160);
            spawnTime = 4;
            nureinmal = true;
            nureinmal2 = true;
            hindernisList.Clear();
            nureinmal3 = true;
            nureinmal4 = true;
            nureinmal5 = true;
            nureinmal6 = true;
            nureinmal7 = true;
            nureinmal8 = true;
            nureinmal9 = true;
            spacecounter = 0;
            delaycounter = 0;
            messagenr = 0;
            skip = false;
            skiplabel.Visible = false;
            skipdescription.Visible = false;
            Hindernisdazu = false;
            Hindernissmove = true;
            playerrecteck.Y = (int)(screenH / 4f * 3f - screenH / 20f + 0.5);
            menurestartbutton = 0;
            Spielbeginnen.Text = "Drücke Leertaste oder Klicke um das Spiel zu beginnen";
            Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));
            Spielbeginnen.Visible = true;
            weiter();
            BackgroundMediaPlayer.settings.volume = 40;
            spielfeldMenuSwitch.Setrestart(0);
        }

        public void pause()
        {
            BackgroundMediaPlayer.settings.volume = 15;
            Hindernissmove = false;
            if (moveUp == true)
            {
                ufä = true;
            }

            else if (moveDown == true)
            {
                abä = true;
            }

            moveUp = false;
            moveDown = false;
            spielgestarted = false;
        }

        public void weiter()
        {
            BackgroundMediaPlayer.settings.volume = 40;
            if (ufä == true)
            {
                moveUp = true;
                moveDown = false;
                ufä = false;
                abä = false;
            }

            else if (abä == true)
            {
                moveUp = false;
                moveDown = true;
                ufä = false;
                abä = false;
            }

            if (!vorspielstart)
            {
                spielgestarted = true;
                Hindernissmove = true;
            }
        }

        private void spawnTimerEvent(object sender, EventArgs e)
        {
            if (spielgestarted && Hindernisdazu)
            {
                spawnTime--;
            }

            if (spawnTime <= 0 && spielgestarted)
            {
                MakeHinderniss();
                spawnTimeCounter++;

                if (level == 1)
                {
                    spawnTime = 15;
                }

                if (level == 2)
                {
                    spawnTime = 5;
                }

                if (level == 3)
                {
                    spawnTime = 4;
                }

                if (level == 4)
                {
                    spawnTime = 3;
                }

                if (level == 5)
                {
                    spawnTime = 2;
                }

                if (level >= 6)
                {
                    spawnTime = 1;
                }

            }
            //spawnAnzeiger.Text = "HindernisCounter: " + spawnTimeCounter.ToString() + "  |  spawn-cooldown: " + spawnTime.ToString();


            if (gameOver.Visible && nureinmal3 && delayCounter >= 1)
            {
                nureinmal3 = false;
                spielgestarted = false;
                Hindernissmove = false;

                BackgroundMediaPlayer.settings.volume = 15;

                Pause = false;
                pauseButton.Image = Image.FromFile(@"./Images/pausebutton.png");

                TutOverScreen tutOverScreen = new TutOverScreen();
                tutOverScreen.TopMost = true;
                tutOverScreen.Show();
            }

            if (gameOver.Visible && delayCounter < 1)
            {
                delayCounter++;
                Hindernissmove = false;
            }
        }

        private void Tuttry_Paint(object sender, PaintEventArgs e)
        {
            ScoreGross.Draw(e.Graphics);
            levelText.Draw(e.Graphics);
            e.Graphics.FillEllipse(Brushes.Black, playerrecteck);
            // Hindernisse zeichnen
            foreach (Hindernis hindernis in hindernisList)
            {
                hindernis.draw(e.Graphics);
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            clicksound.Play();
            nureinmal4 = false;
            if (Pause1 == false && nureinmal4 == false)
            {
                Pause1 = true;
                //pause1();
                pause();
                nureinmal4 = true;
            }
            if (Pause1 == true && nureinmal4 == false)
            {
                Pause1 = false;
                //weiter1();
                weiter();
                nureinmal4 = true;
            }
        }

        private void delayTimer_Event(object sender, EventArgs e)
        {
            delaycounter--;
        }

        private void skiplabel_Click(object sender, EventArgs e)
        {
            if (skip && Pause1 == false)
            {
                delaycounter = 0;
            }
        }


        /* private void SpaceTimerEvent(object sender, EventArgs e)
         {
             spacefix = true;
         }  */
    }
}