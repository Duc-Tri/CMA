using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{


    public class MyDate
    {
        static string[] joursSemaine = //["Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche"];
            new string[] { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };

        private int day;
        private int month;
        private int year;
        public enum WeekDay { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

        public MyDate(int j, int m, int a)
        {
            day = j;
            month = m;
            year = a;

            if (year < 1582)
            {
                Console.Error.WriteLine("YEAR NOT VALID");
                //throw new ArgumentOutOfRangeException("YEAR NOT VALID");
            }
            if (month < 1 || month > 12)
            {
                Console.Error.WriteLine("MONTH NOT VALID");
                //throw new ArgumentOutOfRangeException("MONTH NOT VALID");
            }
            if (j < 1 || j > 31)
            {
                Console.Error.WriteLine("DAY NOT VALID");
                //throw new ArgumentOutOfRangeException("DAY NOT VALID");
            }
            //
            if ((month == 4 || month == 6 || month == 9 || month == 11) && j > 30)
            {
                Console.Error.WriteLine("DAY NOT VALID");
                //throw new ArgumentOutOfRangeException("DAY NOT VALID");
            }
            //
            if (month == 2 && !isBissextile(year) && day > 28)
            {
                Console.Error.WriteLine("YEAR NOT BISSEXTILE " + year);
                //throw new ArgumentOutOfRangeException("YEAR NOT BISSEXTILE");
            }
        }

        public static bool isBissextile(int year)
        {
            /*
            Le calendrier grégorien reste un calendrier solaire se basant non sur la révolution
            de la Terre autour du Soleil (hypothèse non validée à l'époque), mais sur le retour
            au point vernal du soleil chaque printemps, permettant le calcul du début de l'année
            quelques jours après le solstice d'hiver, en 365,2421898 jours de 24 heures. Le calendrier
            grégorien donne un temps moyen de l'année de 365,2425 jours. Pour assurer un nombre entier
            de jours à l'année, on y ajoute tous les 4 ans (années dont le millésime est divisible
            par 4) un jour intercalaire, le 29 février (voir année bissextile), à l'exception des
            années séculaires qui ne sont bissextiles que si leur millésime est divisible par 400.

            On considéra donc comme années communes (années de 365 jours) les millésimes qui sont
            multiples de 100 sans être multiples de 400. Ainsi 1600 et 2000 furent bissextiles, 
            mais pas 1700, 1800, 1900 qui furent communes. De même, 2100, 2200, 2300 seront 
            communes, alors que 2400 sera une année bissextile.
            (wikipedia)
            */
            return (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
        }



        public static string Jour(int i)
        {
            return joursSemaine[i];
        }

        public static WeekDay getWeekDay(int day, int month, int year)
        {
            /*
             Pour une date de la forme jour/mois/année où "jour" prend une valeur de 01 à 31, 
             "mois" de 01 à 12 et "année" de 1583 à 9999, utiliser la formule :
            c = (14 - mois)/12
            En fait, c = 1 pour janvier et février, c = 0 pour les autres mois.
            a = année - c
            m = mois + 12*c - 2
            j = ( jour + a + a/4 - a/100 + a/400 + (31*m)/12 ) mod 7
            La réponse obtenue pour j correspond alors à un jour de la semaine suivant :
            0 = dimanche, 1 = lundi, 2 = mardi, etc.
            */

            int c = (14 - month) / 12;
            int a = year - c;
            int m = month + 12 * c - 2;
            int j = (day + a + (a / 4) + (a / 100) + (a / 400) + ((31 * m) / 12)) % 7;

            return (WeekDay)j; // FAUX !!!

        }

    }



}
