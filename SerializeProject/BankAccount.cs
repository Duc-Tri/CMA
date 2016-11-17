using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    class BankAccountMain
    {
        static void Main(string[] args)
        {
            //testBankAccount();
            testSwitch();
            Console.ReadKey();
        }
        //
        private static void testSwitch()
        {
            Season.writeSeason(11);
            Season.writeSeason(1);
            Season.writeSeason(3);
            Season.writeSeason(6);
            Season.writeSeason(9);
            Season.writeSeason(19);
            Season.writeSeason(-1);
            /*
            Console.WriteLine(Season.whichSeason(12));
            Console.WriteLine(Season.whichSeason(6));
            */
        }

        private static void testBankAccount()
        {
            BankAccount bankaccount01 = new BankAccount("Duc-Tri", 1);
            bankaccount01.add(300);
            bankaccount01.display();
            bankaccount01.add(-1500);
            bankaccount01.display();
            Console.WriteLine();
            //
            BankAccount bankaccount02 = new BankAccount("Cunégonde", 2);
            bankaccount02.add(-20);
            bankaccount02.display();
            bankaccount02.add(500);
            bankaccount02.display();
            bankaccount02.add(500000000);
        }
    }


    class Season
    {
        //-----------------------------------------------------------------------------------------
        public enum Months
        {
            Janvier = 1, Février, Mars, Avril, Mai, Juin, Juillet, Août, Septembre, Octobre, Novembre, Décembre
        }
        //-----------------------------------------------------------------------------------------
        public enum Seasons
        {
            Printemps, Eté, Automne, Hiver
        }

        //-----------------------------------------------------------------------------------------
        static private Dictionary<Seasons, List<Months>> monthSeason = new Dictionary<Seasons, List<Months>>()
         { { Seasons.Printemps, new List<Months>() { Months.Mars, Months.Avril, Months.Mai } },
           { Seasons.Eté, new List<Months>() { Months.Juin, Months.Juillet, Months.Août } },
           { Seasons.Automne, new List<Months>() { Months.Septembre, Months.Octobre, Months.Novembre } },
           { Seasons.Hiver, new List<Months>() { Months.Décembre, Months.Janvier, Months.Février } }
         };

        //=========================================================================================
        static public void writeSeason(int mont)
        {
            Console.WriteLine("mois:" + (Months)mont + " saison:" + whichSeason(mont));
        }

        static public Seasons? whichSeason(int mont)
        {
            NewMyMethod();

            Seasons? s0 = null; // si mont pas bon !!!
            foreach (Seasons s in monthSeason.Keys)
            {
                if (monthSeason[s].Contains((Months)mont))
                {
                    s0 = s;
                    break;

                }
            }
            return s0;
        }

        private static void NewMyMethod()
        {

        }
    }





    [Serializable]
    class BankAccount
    {
        private string user = "";
        private int gender = -1;
        private decimal bankAccount = 0;
        private decimal amount;
        //private string operationType;

        //=========================================================================================
        public BankAccount(string name, int g)
        {
            user = name;
            gender = g;

            if (gender != 1 && gender != 2)
            {
                Console.WriteLine("GENDER DOIT ETRE 2(femme) ou 1(homme). Je le mets à 1 si erreur !");
                gender = 1;
            }
            bankAccount = 0;

            string str = "Création du compte de " + genderString() + user;

            Console.WriteLine(str);
        }
        //=========================================================================================
        public void display()
        {
            string str = "Le compte de " + genderString() + user + " est " + //
                (bankAccount >= 0 ? "CREDITEUR " : "DEBITEUR") + " de (" + bankAccount + ") euros " + //
                " # Dernière opération : (" + (amount >= 0 ? "+" : "") + amount + ")";

            Console.WriteLine(str);
        }
        //=========================================================================================
        public void add(decimal _am)
        {
            if (_am > 1000000 || _am < -1000000)
            {
                Console.WriteLine("Vous ne pouvez pas DEBITER ou CREDITER cette somme !!!");
                return;
            }

            amount = _am;
            bankAccount += amount;

            string str = "Opération sur le compte de " + genderString() + user + //
                " de (" + (amount >= 0 ? "+" : "") + amount + ") euros";

            Console.WriteLine(str);
        }
        //=========================================================================================
        private string genderString()
        {
            return (gender == 2 ? "Madame " : "Monsieur ");
        }
        //=========================================================================================
        public decimal montant
        {
            get { return bankAccount; }
        }

    }
}

