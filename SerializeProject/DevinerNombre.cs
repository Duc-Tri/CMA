using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    class DevinerNombre
    {
        static private int ALEATOIRE = -1;
        static private int NB_COUPS = 0;
        static private int MIN = 0;
        static private int MAX = 199;
        public static int jeuPlusOuMoins(int nombre)
        {
            if (ALEATOIRE < nombre)
                return 1;
            if (ALEATOIRE > nombre)
                return -1;
            //
            return 0; // égal
        }

        private static void gagner()
        {
        }

        public static void demanderJoueur()
        {
            if (ALEATOIRE < 0)
            {
                ALEATOIRE = new Random().Next(MIN, MAX + 1);
                NB_COUPS = 0;
            }

            int val = -1;
            bool isnumber = false;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine((NB_COUPS + 1) + ") Entrer un nombre entre {0} et {1}  : ", MIN, MAX);
                Console.Beep(262, 800);
                isnumber = int.TryParse(Console.ReadLine(), out val);
            }
            while (!isnumber);

            NB_COUPS++;

            switch (jeuPlusOuMoins(val))
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("BRAVO ! TROUVE " + ALEATOIRE + " nombre de coups:" + NB_COUPS);
                    ALEATOIRE = -1;
                    Console.WriteLine("===================================");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("TROP GRAND !");
                    break;
                case -1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("TROP PETIT !");
                    break;
            }
        }


    }
}

