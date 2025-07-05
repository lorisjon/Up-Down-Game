using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Up_down_Game
{
    public static class spielfeldMenuSwitch
    {
            public static int restart { get; private set; }
            public static int pausweiter { get; private set; }

            public static int level { get; private set; }

            public static int score { get; private set; }


            public static byte closemenu { get; private set; }

            public static byte closespiel { get; private set; }

            public static byte closetut { get; private set; }

            public static void Setrestart(int number)
            {
                restart = number;
            }

        public static void Setpausweiter(int pause)
        {
            pausweiter = pause;
        }

        public static void Setlevel (int zahl)
        {
            level = zahl;
        }

        public static void Setscore (int scorezahl)
        {
            score = scorezahl;
        }
        

        public static void Setclosemenu (byte closemenunumber)
        {
            closemenu = closemenunumber;
        }

        public static void Setclosespiel (byte closespielzahl)
        {
            closespiel = closespielzahl;
        }

        public static void Setclosetut (byte closetutzahl)
        {
            closetut = closetutzahl;
        }
    }
}
