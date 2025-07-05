using System.Diagnostics;
using System.Drawing;
using System.Security.Policy;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static Up_down_game_5.Spielfeld;
using Microsoft.VisualBasic;
using System.Media;
using Up_down_Game;
using System.Drawing.Text;
using System.ComponentModel;



namespace Up_down_game_5
{
    public partial class Spielfeld : Form
    {
        //movement für die Spielfigur
        private bool moveUp, moveDown;

        //booleans damit einige aktionen nur einmal ausgeführt werden
        //un beim restart werden die meisten dieser werte wieder auf true gestzt
        private bool nureinmal = true;
        private bool nureinmal2 = true;
        private bool nureinmal3 = true;
        private bool nureinmal4 = true;

        //boolean ob das Spiel gestarted ist oder nicht
        private bool spielgestarted = false;

        //zum checken ob die Platformen schon berührt wurden / ob sie noch punkte geben können oder nicht
        private bool p1active = true;
        private bool p2active = true;

        //booleans für die Pause funktion
        private bool Pause = false;
        private bool ufä, abä;
        private bool Hindernissmove = true;
        private bool vorspielstart = true;

        Rectangle playerrecteck;

        private int speedSF = 0; // Speed Spiel Figur
        private int speedH = 0; // Speed Hinderniss


        private int colorChangeTime = 8; //farbänderung der Platten oben und Unten
        private int level = 0;

        Random rand = new Random();

        //Hinderniss Variablen
        private int x, y;
        private int spawnTime = 4;
        int[] sizes2 = { 1, 2, 3 };
        int[] linksrechts = { 0, 1 };

        //diverse Counters
        private int hindernissCounter = 0;
        private int spawnTimeCounter = 0;
        private int scoreCounter = 0;
        private int speedUpCounter = 0;
        private int delayCounter = 0;
        private int Highscore;

        List<Hindernis> hindernisList = new List<Hindernis>(); //liste für das Speichern der Hindernisse und auch fürs entfernen der Hindernisse

        //Textboxes die ich mit Draw zeichne damit sie hinter Spielfigur und Hindernisse sind
        TextBox levelText;
        TextBox ScoreGross;
        TextBox Highscoret;

        private int screenW;
        private int screenH;
        private int pauseweiter;
        private int menurestartbutton = 0;
        private byte closeSpiel = 0;

        /*Die verschiedenen Soundeffekte*/
        /* falls diese Dateien nicht gefunden werden (vom Computer) fange ich dies mit try und catch ab*/
        SoundPlayer oversound = new SoundPlayer(@"./Soundeffects/short-beep-tone-louder.wav");
        SoundPlayer clicksound = new SoundPlayer(@"./Soundeffects/ui-click-louder.wav");
        SoundPlayer bloop = new SoundPlayer(@"./Soundeffects/bloop-2.wav");
        SoundPlayer swipeDown = new SoundPlayer(@"./Soundeffects/swing-whoosh-5-quiet.wav");

        /* variablen bei denen ich werte gebe die ich ürprünglich jedes mal wieder berechnet habe, welche aber immer gleich bleiben*/
        
        /*für movetimerevent*/
        private int posrech1;
        private int posrech2;

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


        public Spielfeld()
        {
            InitializeComponent();

            //vermidert lags
            this.DoubleBuffered = true;

            screenW = Screen.GetBounds(this).Width; //nimmt die Breite des Gerätes welches der User benutzt / auf dem das Spiel läuft
            screenH = Screen.GetBounds(this).Height;//nimmt die Höhe des Bildschirm, vom Gerät welches der User für das Game benutzt.

            this.Size = new Size(screenW, screenH);

            //Die Spielfigur Erstellen
            playerrecteck = new Rectangle((int)(screenW / 2f - screenH / 40f + 0.5), (int)(screenH / 4f * 3f - screenH / 20f + 0.5), (int)(screenH / 20f + 0.5), (int)(screenH / 20f + 0.5));

            levelText = new TextBox(new Rectangle((int)(screenW / 2f - ((screenW / (1920f / 256f)) / 2f) + 0.5f), (int)(screenH / 15f + 0.5f), (int)(screenW / (1920f / 256f) + 0.5), (int)(screenH / (1200f / 129f) + 0.5)), "Level 0", "Agency FB", (int)(screenW / (1920f / 54f) + 0.5), Color.Transparent, Color.FromArgb(255, 139, 139, 138));
            ScoreGross = new TextBox(new Rectangle((int)(screenW / 2f - ((screenW / (1920f / /*379f*/568.5f) + 0.5) / 2f) + 0.5), (int)(screenH / 2f - ((screenH / (1200f / 307f/*460.5*/) + 0.5) / 2f) + 0.5), (int)(screenW / (1920f / /*379f*/568.5f) + 0.5), (int)(screenH / (1200f / 307f /*460.5f*/) + 0.5)), "0", "Segoe UI", (int)(screenH / (1200f / 200f/*166f*//*249f*/) + 0.5), Color.Transparent, Color.FromArgb(255, 139, 139, 138));

            /*die Werte für die Oben erstellten Variable für das erstellen von Hindernissen geben*/
            //die Drei grössen der Hindernisse
            sizes2[0] = (int)(screenH / (1200f / 70f) + 0.5);
            sizes2[1] = (int)(screenH / (1200f / 40f) + 0.5);
            sizes2[2] = (int)(screenH / (1200f / 90f) + 0.5);

            linksrechts[1] = screenW; //damit einige Hindernisse rechts vom Bildschirm sind

            //Plattform 1 (oben)
            p1.Size = new Size((int)(screenW / (1920f / 477f) + 0.5), (int)(screenH / (1200f / 12f) + 0.5));
            p1.Location = new Point((int)(screenW / 2f - p1.Width / 2f + 0.5), (int)(screenH / 40f + 0.5));
            p1.BackColor = Color.FromArgb(255, 43, 112, 160);

            pauseButton.Size = new Size((int)(screenH / (1200f / 100f) + 0.5), (int)(screenH / (1200f / 100f) + 0.5));
            pauseButton.Location = new Point(p1.Location.X - p1.Width, (int)(screenH / 100f + 0.5));

            //Plattform 2 (unten)
            p2.Size = new Size((int)(screenW / (1920f / 477f) + 0.5), (int)(screenH / (1200f / 12) + 0.5));
            p2.Location = new Point((int)(screenW / 2f - p2.Width / 2f + 0.5), (int)(screenH / 40f * 36f - p2.Height + 0.5));
            p2.BackColor = Color.FromArgb(255, 43, 112, 160);

            //Text vor Spielbeginn
            Spielbeginnen.Font = new Font("Bernard MT Condensed", (int)(screenH / (1200f / 33f) + 0.5) /*(int)(Spielbeginnen.Width / (959f / 22f))*/, FontStyle.Regular);
            Spielbeginnen.Location = new Point((int)(/* p2.Location.X */screenW / 2f - Spielbeginnen.Width / 2f + 0.5), (int)(screenH / 4f));


            gameOver.Font = new Font("Bernard MT Condensed", (int)(screenH / (1200f / 108f) + 0.5));
            gameOver.Location = new Point((int)(screenW / 2f - gameOver.Width / 2f + 0.5), (int)(screenH / 5f + 0.5));

            //Label für das Anzeigen von Errors
            notifylabel.Visible = false;
            notifylabel.Font = new Font("Segoe", (int)(screenH / (1200f / 20f) + 0.5));
            notifylabel.Location = new Point(0, (int)(screenH - (notifylabel.Height * 3)));


            //Die Highscore variable bekommt der Wert von einer art "lokalen Datenbank"
            //so kann der wert auch beibehlaten werden wenn das Spiel geschlossen ist
            Highscore = Up_down_Game.Properties.Settings.Default.Highscore;

            //Textbox die den Highscore anzeigt
            Highscoret = new TextBox(new Rectangle((int)((p1.Location.X + p1.Width * 2) - ((screenW / (1920f / 750f) + 0.5) / 2f))/*(screenW / 50f + 0.5)*/, 0/*(screenH / 10f + 0.5)*/, (int)(screenW / (1920f / 750f) + 0.5), (int)(screenH / (1200f / 150f) + 0.5)), "Highscore: " + Highscore.ToString(), "Agency FB", (int)(screenH / (1200f / 54f) + 0.5), Color.Transparent, Color.FromArgb(255, 139, 139, 138));

            //Hintergrundsmusik
            /* falls diese Dateien nicht gefunden werden (vom Computer) fange ich dies mit try und catch ab*/
            BackgroundMediaPlayer.URL = @"./Soundeffects/Backgroundmusicwhole.mp3";
            BackgroundMediaPlayer.Ctlcontrols.stop();
            BackgroundMediaPlayer.Visible = false;
            BackgroundMediaPlayer.settings.playCount = 9999;

            //Berechnung der Variablen inhalte für movetimerevent
            posrech1 = (int)(p1.Location.Y + p1.Height / 2);
            posrech2 = (int)(p2.Location.Y - playerrecteck.Height + p2.Height / 2);

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


        // Erstellen von Hindernissen
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

            Hindernis hindernis;

            //Ab dem vierten Level werden die Hindernisse Schwarz generiert
            if (level >= 4)
            {
                hindernis = new Hindernis(new Rectangle(x, y, gösi, gösi), x, y, Color.Black, richtig, speedH);

            }

            else
            {
                hindernis = new Hindernis(new Rectangle(x, y, gösi, gösi), x, y, Color.FromArgb(255, 155, 23, 55), richtig, speedH);
            }
            hindernisList.Add(hindernis);



            //sobald 5 Hindernisse gleichzeitig "existieren" wird das erste gelöscht
            //so werden die Hindernisse die ausserhalb des Bildschirms sind gelöscht
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

        //moveTimerEvent wird all 16ms aufgerufen (62.5 fps)
        //Timer Beinhaltet:
        //änderung der Position von Spielfigur und Hindernis
        //die Farbe der Plattformen
        //das Zählen der Punkte
        private void moveTimerEvent(object sender, EventArgs e)
        {
            Invalidate(); //Das Programm wird gezwungen alles noch einmal neu zu zeichnen
            if (moveUp == true && playerrecteck.Y > posrech1 && spielgestarted == true) //Hier wird auch noch gechecked das die Spielfigur
                                                                                        //nie hinter der Plattform 1 ist
            {
                playerrecteck.Y -= speedSF;
            }

            if (moveDown == true && playerrecteck.Y < posrech2 && spielgestarted == true)//und Hier wird geschecked das sie nie
                                                                                         //weiter als die Plattform 2 ist
            {
                playerrecteck.Y += speedSF;
            }

            if (playerrecteck.Y <= posrech1 && spielgestarted == true) //jedesmal wenn die Spielfigur der Platform 1 ankommt
            {
                moveUp = false;
                moveDown = true;

                try
                {
                    bloop.Play(); //sound wenn die Spielfigur der unteren Plattform ankommt
                }

                catch
                {
                    notifylabel.Text = "Sound not Found";
                    notifylabel.Visible = true;
                    notifytimer.Start();
                }

                if (p1active)
                {
                    scoreCounter++;
                    spielfeldMenuSwitch.Setscore(scoreCounter);
                    p1active = false;
                    p2active = true;

                    p1.BackColor = Color.FromArgb(255, 177, 207, 108); //Die plattform 1 wird grün
                    p2.BackColor = Color.FromArgb(255, 43, 112, 160); // und die Platttform zwei wird blau
                }
            }


            if (playerrecteck.Y >= posrech2 && spielgestarted == true) //jedesmal wenn die Spielfigur der Platform 2 ankommt
            {
                moveUp = true;
                moveDown = false;
                try
                {
                    bloop.Play(); //sound wenn die Spielfigur der unteren Plattform ankommt
                }

                catch
                {
                    notifylabel.Text = "Sound not Found";
                    notifylabel.Visible = true;
                    notifytimer.Start();
                }

                if (p2active)
                {
                    scoreCounter++;
                    spielfeldMenuSwitch.Setscore(scoreCounter);
                    p1active = true;
                    p2active = false;

                    p2.BackColor = Color.FromArgb(255, 177, 207, 108); //die Plattform 2 wird Grün
                    p1.BackColor = Color.FromArgb(255, 43, 112, 160); //und die Plattform 1 wird Blau
                }
            }






            //die Collisionsfunktion, das detected von Collisionen
            foreach (Hindernis hindernis in hindernisList)
            {
                if (playerrecteck.IntersectsWith(hindernis.bounds) && nureinmal2 == true) //Hier wird geschecked ob die Spielfigur
                                                                                          //einem Hinderniss ankommt
                {
                    spielgestarted = false;
                    Hindernissmove = false;
                    moveUp = false;
                    moveDown = false;
                    nureinmal2 = false;
                    gameOver.Enabled = true;
                    gameOver.Visible = true;

                    try
                    {
                        oversound.Play();
                    }

                    catch
                    {
                        notifylabel.Text = "Sound not Found";
                        notifylabel.Visible = true;
                        notifytimer.Start();
                    }
                }
            }

            foreach (Hindernis hindernis in hindernisList) //Hier wird jedes Hinderniss bewegt
            {
                if (Hindernissmove == true)
                {
                    hindernis.move();
                }
            }


        }





        private void mouseclick(object sender, MouseEventArgs e)
        {
            if (moveUp && Pause == false)
            {
                moveUp = false;
                moveDown = true;

                try
                {
                    swipeDown.Play();
                }

                catch
                {
                    notifylabel.Text = "Sound not Found";
                    notifylabel.Visible = true;
                    notifytimer.Start();
                }
            }


            else if (moveDown && Pause == false)
            {
                moveUp = true;
                moveDown = false;

                try
                {
                    swipeDown.Play();
                }

                catch
                {
                    notifylabel.Text = "Sound not Found";
                    notifylabel.Visible = true;
                    notifytimer.Start();
                }
            }

            else if (moveDown == false && moveUp == false && Pause == false)
            {
                Spielbeginnen.Visible = false;
                spielgestarted = true;
                vorspielstart = false;
                Hindernissmove = true;
                moveUp = true;
                moveDown = false;
                BackgroundMediaPlayer.settings.volume = 40;

                try
                {
                    BackgroundMediaPlayer.Ctlcontrols.play();
                }

                catch
                {
                    notifylabel.Text = "Backgroundmusic wasn't found";
                    notifylabel.Visible = true;
                    notifytimer.Start();
                }
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


        //wenn die Leertaste gedrückt wird
        private void spaceDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (moveUp && Pause == false)
                {
                    moveUp = false;
                    moveDown = true;
                    try
                    {
                        //sound spielt jedes mal wenn Leertaste gedrückt wird und richtung geändert wird
                        swipeDown.Play();
                    }

                    catch
                    {
                        notifylabel.Text = "Sound not Found";
                        notifylabel.Visible = true;
                        notifytimer.Start();
                    }
                }


                else if (moveDown && Pause == false)
                {
                    moveUp = true;
                    moveDown = false;

                    try
                    {
                        //sound spielt jedes mal wenn Leertaste gedrückt wird und richtung geändert wird
                        swipeDown.Play();
                    }

                    catch
                    {
                        notifylabel.Text = "Sound not Found";
                        notifylabel.Visible = true;
                        notifytimer.Start();
                    }
                }


                //fals die Spielfigur stillsteht, beim aller ersten klick (bei jedem Spiel / bei jeder Wiederholung)
                else if (moveDown == false && moveUp == false && Pause == false)
                {
                    Spielbeginnen.Visible = false;
                    spielgestarted = true;
                    vorspielstart = false;
                    Hindernissmove = true;
                    moveUp = true;
                    moveDown = false;
                    BackgroundMediaPlayer.settings.volume = 40;

                    try
                    {
                        //started die Hintergrundsmusik
                        BackgroundMediaPlayer.Ctlcontrols.play();
                    }

                    catch
                    {
                        notifylabel.Text = "Backgroundmusic wasn't Found";
                        notifylabel.Visible = true;
                        notifytimer.Start();
                    }
                }
            }

            if (e.KeyCode == Keys.Escape)
            {

                pause();
                spielfeldMenuSwitch.Setpausweiter(0);
                
                //die Menu Form wird aufgerufen / gestarted
                Menu menu = new Menu();
                menu.TopMost = true; //ist immer zu vorderst / zu oberst als Form/Fenster
                menu.Show();
            }
        }


        //Timer beinhaltet: 
        //was vor dem Spielbeginn passiert sprich: spielbeginn label ("Drücke Leertast oder Klicke um das Spiel zu beginnen")
        //das ändern von grün zu grau der Plattformen p1 und p2
        //das Anzeigen vom Score / den Scoreanzeiger
        //das ändern des Highscores
        //das Speichern des Levels im Spielfeldmenuswitch
        //das Anzeigen der Level / der Level Text
        //die Farben der Level
        //die Pause, Weiter und Schliess funktionen des Menu's
        private void generellTimerEvent(object sender, EventArgs e)
        {
            
            //vor dem spielbeginn, wenn sich der spieler nicht bewegt
            if (moveUp == false && moveDown == false && nureinmal == true)
            {
                nureinmal = false;
                Spielbeginnen.Visible = true;
            }

            //falls eine der Platformen grün ist
            if (p1.BackColor == Color.FromArgb(255, 177, 207, 108) || p2.BackColor == Color.FromArgb(255, 177, 207, 108))
            {
                colorChangeTime--;
            }

            //wenn die Colorchangetime 0 (oder kleiner) ist wechselt die farbe von grün zu grau
            if (colorChangeTime <= 0)
            {
                colorChangeTime = 8;
                if (p1.BackColor == Color.FromArgb(255, 177, 207, 108))
                {
                    p1.BackColor = Color.FromArgb(255, 94, 94, 93);
                }

                else if (p2.BackColor == Color.FromArgb(255, 177, 207, 108))
                {
                    p2.BackColor = Color.FromArgb(255, 94, 94, 93);
                }
            }


            //Highscore
            //falls der Score höher als der aktuelle Highscore ist, wird der Highscore aktuallisirt
            if (scoreCounter > Highscore)
            {
                Highscore = scoreCounter;
                Highscoret.ChangeText("Highscore: " + Highscore.ToString());
            }

            //das anzeigen des Scores
            ScoreGross.ChangeText("" + scoreCounter.ToString());



            //Das zuteilen der Level
            if (scoreCounter < 5) //von score 1 bis 5 = level 1
            {
                level = 1;
                spielfeldMenuSwitch.Setlevel(level);
            }

            else if (scoreCounter > 4 && scoreCounter < 15) //von score 5 bis 15 = level 2
            {
                level = 2;
                spielfeldMenuSwitch.Setlevel(level);
            }

            else if (scoreCounter > 14 && scoreCounter < 25) //etc.
            {
                level = 3;
                spielfeldMenuSwitch.Setlevel(level);
            }


            else if (scoreCounter > 24 && scoreCounter < 35)
            {
                level = 4;
                spielfeldMenuSwitch.Setlevel(level);
            }

            else if (scoreCounter > 34 && scoreCounter < 45)
            {
                level = 5;
                spielfeldMenuSwitch.Setlevel(level);
            }

            else if (scoreCounter > 44 && scoreCounter < 55)
            {
                level = 6;
                spielfeldMenuSwitch.Setlevel(level);
            }

            else if (scoreCounter > 54 && scoreCounter < 65)
            {
                level = 7;
                spielfeldMenuSwitch.Setlevel(level);
            }

            else if (scoreCounter > 64 && scoreCounter < 75)
            {
                level = 8;
                spielfeldMenuSwitch.Setlevel(level);
            }

            else if (scoreCounter > 74 && scoreCounter < 85)
            {
                level = 9;
                spielfeldMenuSwitch.Setlevel(level);
            }

            else if (scoreCounter > 84)
            {
                level = 10;
                spielfeldMenuSwitch.Setlevel(level);
            }

            //level anzeigen
            levelText.ChangeText("Level " + level.ToString());



            //farben der Level
            //Farbdesign ist nach Corbussier
            switch (level)
            {
                case 1:
                    this.BackColor = Color.FromArgb(255, 137, 191, 199);
                    speedSF = speedrech1;
                    speedH = speedrech2;
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



            //funktionen des Menus für im "Spielfeld" form:
            //pause und weiter
            //restart
            //und exit ins Haupt-/StartMenu
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
                restart();
            }

            closeSpiel = spielfeldMenuSwitch.closespiel;

            if (closeSpiel == 1)
            {
                closeSpiel = 0;
                spielfeldMenuSwitch.Setclosespiel(0);
                if (gameOver.Visible)
                {
                    StartMenu startMenu = new StartMenu();
                    startMenu.Show();
                    this.Close();
                }

                else
                {
                    DialogResult dialogResult = MessageBox.Show("willst du dass Spiel wirklich verlassen?", "Exit? ReAlY?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            clicksound.Play();
                        }

                        catch
                        {
                            notifylabel.Text = "Sound not Found";
                            notifylabel.Visible = true;
                            notifytimer.Start();
                        }
                        StartMenu startMenu = new StartMenu();
                        startMenu.Show();
                        this.Close();
                    }
                    if (dialogResult == DialogResult.No)
                    {
                        try
                        {
                            clicksound.Play();
                        }

                        catch
                        {
                            notifylabel.Text = "Sound not Found";
                            notifylabel.Visible = true;
                            notifytimer.Start();
                        }
                        weiter();
                    }
                }

            }

        }

        //neustart funktion
        public void restart()
        {
            /* falls diese Dateie nicht gefunden wird (vom Computer) fange ich dies mit try und catch ab*/
            try
            {
                pauseButton.Image = Image.FromFile(@"./Images/pausebutton.png");
            }

            catch
            {
                notifylabel.Text = "Image not found";
                notifylabel.Visible = true;
                notifytimer.Start();
            }
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
            Hindernissmove = true;
            playerrecteck.Y = (int)(screenH / 4f * 3f - screenH / 20f + 0.5);
            menurestartbutton = 0;
            BackgroundMediaPlayer.settings.volume = 40;
            spielfeldMenuSwitch.Setrestart(0);
        }

        public void pause()
        {
            BackgroundMediaPlayer.settings.volume = 15;
            Pause = true;
            Hindernissmove = false;
            /* falls diese Dateie nicht gefunden wird (vom Computer) fange ich dies mit try und catch ab*/
            try
            {
                pauseButton.Image = Image.FromFile(@"./Images/playbutton.png");
            }

            catch
            {
                notifylabel.Text = "Image not found";
                notifylabel.Visible = true;
                notifytimer.Start();
            }

            if (moveUp == true)
            {
                ufä = true;
            }

            if (moveDown == true)
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
            Pause = false;
            /* falls diese Dateie nicht gefunden wird (vom Computer) fange ich dies mit try und catch ab*/
            try
            {
                pauseButton.Image = Image.FromFile(@"./Images/pausebutton.png");
            }

            catch
            {
                notifylabel.Text = "Image not found";
                notifylabel.Visible = true;
                notifytimer.Start();
            }
            if (ufä == true)
            {
                moveUp = true;
                moveDown = false;
                ufä = false;
                abä = false;
            }

            if (abä == true)
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

        //Timer Beinhaltet:
        //die Spawn rate der Hindernisse 
        //die Game over funktion
        private void spawnTimerEvent(object sender, EventArgs e)
        {
            if (spielgestarted)
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



            if (gameOver.Visible && nureinmal3 && delayCounter >= 2)
            {
                nureinmal3 = false;
                delayCounter = 0;
                BackgroundMediaPlayer.settings.volume = 15;
                spielgestarted = false;
                Hindernissmove = false;

                //Hier wird der Highscore gespeichert
                Up_down_Game.Properties.Settings.Default.Highscore = Highscore;
                Up_down_Game.Properties.Settings.Default.Save();

                Pause = false;
                /* falls diese Dateie nicht gefunden wird (vom Computer) fange ich dies mit try und catch ab*/
                try
                {
                    pauseButton.Image = Image.FromFile(@"./Images/pausebutton.png");
                }

                catch
                {
                    notifylabel.Text = "Image not found";
                    notifylabel.Visible = true;
                    notifytimer.Start();
                }
                GameOverScreen gameOverScreen = new GameOverScreen();
                gameOverScreen.TopMost = true;
                gameOverScreen.Show();
            }

            if (gameOver.Visible && delayCounter < 2)
            {
                delayCounter++;
            }
        }


        //das Zeichnen der verschiedenen Elemente:
        //Textboxen
        //Hindernisse
        private void Spielfeld_Paint(object sender, PaintEventArgs e)
        {
            //Textboxen
            ScoreGross.Draw(e.Graphics);
            levelText.Draw(e.Graphics);
            Highscoret.Draw(e.Graphics);

            e.Graphics.FillEllipse(Brushes.Black, playerrecteck);
            // Hindernisse zeichnen
            foreach (Hindernis hindernis in hindernisList)
            {
                hindernis.draw(e.Graphics);
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            //falls der Sound nicht gefunden wird fange ich dies mit try und catch ab
            try
            {
                clicksound.Play();
            }

            catch
            {
                notifylabel.Text = "Sound not Found";
                notifylabel.Visible = true;
                notifytimer.Start();
            }
            nureinmal4 = false;
            if (Pause == false && nureinmal4 == false)
            {
                nureinmal4 = true;
                pause();
                spielfeldMenuSwitch.Setpausweiter(0); //das nicht dierekt weiter gemacht wird
                                                      //ist Setpauseweiter auf 1 geht das Spiel hier wieder weiter und ist nicht mehr Pausiert
                Menu menu = new Menu();
                menu.TopMost = true;
                menu.Show();
            }
            if (Pause == true && nureinmal4 == false)
            {
                Pause = false;
                weiter();
                nureinmal4 = true;
                spielfeldMenuSwitch.Setclosemenu(1);//damit das Menu geschlossen wird
            }
        }

        //Timer für das Anzeigen von error messages, wenn ich mit try und catch einen
        //Fehler finde kann wird das notifylabel sichtbar und dieser Timer gestarted,
        //sobald der timmer tickt, stopt der Timer und das notifylabel wird wieder unsichtbar
        private void notifytimer_Tick(object sender, EventArgs e)
        {
            notifylabel.Visible = false;
            notifytimer.Stop();
        }
    }


    //mit dieser Klasse wird durch oop (object oriented programming) ein "blueprint" für das Erstellen von Hindernisse
    //diese Klasse wird in der MakeHinderniss methode aufgeruffen
    public class Hindernis
    {
        private int x, y;
        Color farb;
        private int leftright;
        private int speed;
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

        //draw wird für das Erstellen von Hindernissen gebraucht, wird in der MakeHinderniss Methode aufgerufen.
        public void draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(farb), bounds);
        }

        //die move funktion ist für das Bewegen der Hindernisse und wird im movetimerevent aufgerufen
        public void move()
        {
            bounds.X += speed * leftright;
        }
    }


    /* Diesen Code/diese Klasse habe ich mit chatGPT generieren lassen */
    /* die Klasse hat sehr änhliche Funktionen wie ein Label es wird aber mit Draw erstellt */
    /* Ich habe diese Klasse generieren lassen damit ich bestimmte Textboxes hineter anderen objekten haben kann, da ich die meisten Objeke Zeichne*/
    public class TextBox
    {
        public Rectangle Bounds { get; private set; }
        public string Text { get; set; }
        public string refText { get; set; }
        public float FontSize { get; set; }
        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
        public HorizontalAlignment TextAlignment { get; set; } = HorizontalAlignment.Center;
        public HorizontalAlignment LineAlignment { get; set; } = HorizontalAlignment.Center;
        public String FontFamily { get; set; }

        public TextBox(Rectangle bounds, string text = "", string font = "Arial", float fontSize = 10f, Color backgroundColor = default, Color foregroundColor = default, HorizontalAlignment textAlignment = HorizontalAlignment.Center, HorizontalAlignment lineAlignment = HorizontalAlignment.Center)
        {
            Bounds = bounds;
            Text = text;
            FontFamily = font;
            FontSize = fontSize;
            BackgroundColor = backgroundColor == default ? Color.LightGray : backgroundColor;
            ForegroundColor = foregroundColor == default ? Color.Black : foregroundColor;
            TextAlignment = textAlignment;
            LineAlignment = lineAlignment;

        }

        public void ChangeText(string text)
        {
            Text = text;
        }
        public void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(BackgroundColor))
            {
                g.FillRectangle(brush, Bounds);
            }

            using (var pen = new Pen(BackgroundColor))
            {
                g.DrawRectangle(pen, Bounds);
            }

            // Zeichnen Sie den Text in der Mitte des Textfelds
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            switch (TextAlignment)
            {
                case HorizontalAlignment.Left:
                    stringFormat.Alignment = StringAlignment.Near;
                    break;
                case HorizontalAlignment.Center:
                    stringFormat.Alignment = StringAlignment.Center;
                    break;
                case HorizontalAlignment.Right:
                    stringFormat.Alignment = StringAlignment.Far;
                    break;
            }
            switch (LineAlignment)
            {
                case HorizontalAlignment.Left:
                    stringFormat.LineAlignment = StringAlignment.Near;
                    break;
                case HorizontalAlignment.Center:
                    stringFormat.LineAlignment = StringAlignment.Center;
                    break;
                case HorizontalAlignment.Right:
                    stringFormat.LineAlignment = StringAlignment.Far;
                    break;
            }

            using (var font = new Font(FontFamily, FontSize))
            {
                using (var brush = new SolidBrush(ForegroundColor))
                {
                    g.DrawString(Text, font, brush, Bounds, stringFormat);
                }
            }
        }
    }
}







