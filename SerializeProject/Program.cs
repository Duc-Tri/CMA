using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SerializeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //testSerialization();
            //testDate();
            //            testDivers0();



            //testPOO02();

            //testPOO01();
            testPOO03();

            Console.ReadKey();

        }

        private static void testPOO03()
        {
            Animal c = new Cat();
            Dog d = (Dog)c;
            Console.WriteLine("dog ? " +d);


        }

        private static void testPOO02()
        {
            Car car1 = new Car();
            Car car2 = new Car("rouge");

            Object o = new Car("rose");
        }

        private static void testPOO01()
        {
            /*
            Animal animo = new Animal();
            animo.Legs = 3;
            animo.Breath();

            
            Dog adog = new Dog();
            adog.Breath();
            adog.Legs = 4;
            adog.Bark();
            */

            List<Animal> ark = new List<Animal>();
            ark.Add(new Cat("Gros minet"));
            ark.Add(new Dog("Pluto"));
            ark.Add(new Cat("Tom"));
            ark.Add(new Dog("Dingo"));
            ark.Add(new Cat("Isidore"));
            ark.Add(new Dog("Rantanplan"));

            foreach(Animal an in ark)
            {
                an.Breath();
            }
        }

        private static void testDevinenombre()
        {     /*
            bool continuer = false;
            do
            {
                int converted;
                Console.WriteLine("input un truc : ");
                string input = Console.ReadLine();
                int.TryParse(input, out converted);
                Console.WriteLine("resultat de age : " + converted);

                ConsoleKey k;
                Console.WriteLine("continuer ? (o/autre touche) ");
                k = Console.ReadKey().Key;
                continuer = (k == ConsoleKey.O);
            }
            while (continuer);
            */
              /*
              for (;;)
              {
                  DevinerNombre.demanderJoueur();
              }
              */
        }

        private static void testDivers1()
        {


            Car car1 = new Car();
            Car car2 = new Car();

            car1.start();
            car1.run(100);
            //car1.checkSpeed();
            car1.run(140);
            car1.Model = "AUDI ROASTER";
            car1.run(90);
            //car1.checkSpeed();

            car1 = null;

            CoffeeMachine machineCafe = new CoffeeMachine() { ID = 999, ex = 10f };

            Console.WriteLine(machineCafe.ID);
            int id_mc = machineCafe.ID;

            machineCafe.ID = 1;

        }

        private static void testDivers0()
        {
            Console.WriteLine("\t somme entiers consécutifs: " + SumInteger(1, 10));
            Console.WriteLine("\t moyenne : " + Average(new List<double>() { 1.0, 5.5, 9.9, 2.8, 9.6 }));
            //Console.WriteLine("somme entiers communs: "+
            SumMultiple();

            foreach (string p in Environment.GetCommandLineArgs())
            {
                Console.WriteLine("arg: " + p);
            }
        }

        private static int SumMultiple()
        {
            List<int> multiple3 = new List<int>();
            List<int> multiple5 = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                    multiple3.Add(i);
                if (i % 5 == 0)
                    multiple5.Add(i);
            }
            //
            Console.WriteLine("\t multiples de 3: " + afficher(multiple3));
            Console.WriteLine("\t multiples de 5: " + afficher(multiple5));
            //
            int index3 = 0;
            int index5 = 0;
            int somme = 0;
            string chaine = "";
            for (index3 = 0; index3 < multiple3.Count; index3++)
            {
                if (multiple3[index3] == multiple5[index5])
                {
                    chaine += (somme != 0 ? " + " : "") + multiple3[index3];
                    somme += multiple3[index3];
                    index5++;
                }
                else if (multiple3[index3] > multiple5[index5])
                {
                    index5++;
                }
            }

            chaine += " = " + somme;
            Console.WriteLine("\t Somme des entiers communs: " + chaine);

            return somme;
        }

        private static string afficher(List<int> list)
        {
            string chaine = "";
            foreach (double d in list)
                chaine += d + "_";
            //
            return chaine;
        }

        private static double Average(List<double> list)
        {
            double somme = 0;
            foreach (double d in list)
                somme += d;
            //
            return (somme / list.Count);
        }

        private static int SumInteger(int v1, int v2)
        {
            int somme = 0;
            for (int val = v1; val <= v2; val++)
            {
                somme += val;
            }
            return somme;
        }




        //=========================================================================================

        private static void testGreetings()
        {
            testGreetingsDay(DateTime.Now);
            testGreetingsDay(new DateTime(2016, 11, 29, 17, 0, 0)); //bonjour
            testGreetingsDay(new DateTime(2016, 11, 30, 7, 0, 0)); //bonsoir
            testGreetingsDay(new DateTime(2016, 12, 1, 11, 0, 0)); //bonjour
            testGreetingsDay(new DateTime(2016, 12, 2, 15, 0, 0)); //bonjour
            testGreetingsDay(new DateTime(2016, 12, 2, 20, 0, 0)); //bon weekend
            testGreetingsDay(new DateTime(2016, 12, 3, 20, 0, 0)); //bon weekend
            testGreetingsDay(new DateTime(2016, 12, 4, 8, 0, 0)); //bon weekend
            testGreetingsDay(new DateTime(2016, 12, 5, 8, 0, 0)); //bon weekend
            testGreetingsDay(new DateTime(2016, 12, 5, 10, 0, 0)); //bonjour

        }
        //=========================================================================================
        private static void testGreetingsDay(DateTime dt)
        {
            int h = dt.Hour;
            DayOfWeek d = dt.DayOfWeek;
            string username = Environment.UserName; // + "//"+Environment.UserDomainName;
            //
            string greeting = "???";
            /*
            greeting = (d == DayOfWeek.Friday) ? "Bon weekend" : //
                            ((h > 9 && h < 18) ? "Bonjour" : "Bonsoir");
                            // MAUVAIS
                            */

            if ((d <= DayOfWeek.Monday || d >= DayOfWeek.Friday) && (h <= 9 || h >= 18))
                greeting = "Bon weekend";
            else if ((d >= DayOfWeek.Monday && d <= DayOfWeek.Thursday) && (h <= 9 || h >= 18))
                greeting = "Bonsoir";
            else // if ((d >= DayOfWeek.Monday && d <= DayOfWeek.Friday) && (h >= 9 && h <= 18))
                greeting = "Bonjour";

            /*
            switch (d)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    Console.WriteLine("jour de la semaine");
                    break;

                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("weekend");
                    break;

                default:
                    Console.WriteLine("???");
                    break;
            }
            */

            Console.WriteLine(greeting + " " + username + " [" + dt.DayOfWeek + " " + dt.Hour + "h ]");
        }


        //=========================================================================================
        private static void testDate()
        {
            Console.WriteLine(MyDate.Jour(3));

            //Console.WriteLine("CALCUL DU JOUR DE LA SEMAINE 1 : " + MyDate.getWeekDay(1, 12, 2016));
            Console.WriteLine("CALCUL DU JOUR DE LA SEMAINE 2 : " + MyDate.getWeekDay2(1, 12, 2016));
            Console.WriteLine("CALCUL DU JOUR DE LA SEMAINE 2 : " + MyDate.getWeekDay2(2, 12, 2016));
            Console.WriteLine("CALCUL DU JOUR DE LA SEMAINE 2 : " + MyDate.getWeekDay2(3, 12, 2016));
            Console.WriteLine("CALCUL DU JOUR DE LA SEMAINE 2 : " + MyDate.getWeekDay2(24, 12, 1975));

            MyDate d = new MyDate(29, 11, 2016);

            d = new MyDate(29, 2, 1600); // bi
            d = new MyDate(29, 2, 2000); // bi

            d = new MyDate(29, 2, 1700);
            d = new MyDate(29, 2, 1800);
            d = new MyDate(29, 2, 1900);

            d = new MyDate(29, 2, 2100);
            d = new MyDate(29, 2, 2200);
            d = new MyDate(29, 2, 2300);

            d = new MyDate(29, 2, 2400); // bi
        }

        //=========================================================================================
        private static void testSerialization()
        {
            // And then in some function.
            Person person = new Person()
            {
                Name = "Duc-Tri",
                Age = 2,
                HomeAddress = new Address() { StreetAddress = "19 rue Louis Ulbach", City = "Courbevoie" }
            };


            List<Person> people = GenerateListOfPeople();
            XmlSerialization.WriteToXmlFile<Person>("person.txt", person);
            XmlSerialization.WriteToXmlFile<List<Person>>("list_people.txt", people);

            // Then in some other function.
            person = XmlSerialization.ReadFromXmlFile<Person>("person.txt");
            people = XmlSerialization.ReadFromXmlFile<List<Person>>("list_people.txt");

            Console.WriteLine(person.ToString());
            Console.WriteLine(Person.display(people));
        }
        //=========================================================================================
        private static List<Person> GenerateListOfPeople()
        {
            //const int MAX_PEOPLE = 10;
            return new List<Person> { new Person() { Name = "Gertrude", Age = 10, HomeAddress = new Address() { StreetAddress = "rue de la République", City = "Marseille" } },
                new Person() { Name = "Dominique", Age = 11, HomeAddress = new Address() { StreetAddress = "rue des fleurs", City = "Lille" }},
                new Person() { Name = "Christophe", Age = 12, HomeAddress = new Address() { StreetAddress = "rue du zoo", City = "Arles" }},
                new Person() { Name = "Gregory", Age = 13, HomeAddress = new Address() { StreetAddress = "rue félix faure", City = "Strasbourg" }},
                new Person() { Name = "Sabrina", Age = 14, HomeAddress = new Address() { StreetAddress = "boulevard Magenta", City = "Lyon" }}
            };
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age = 20;
        public Address HomeAddress { get; set; }
        private string _thisWillNotGetWrittenToTheFile = "because it is not public.";

        public override string ToString()
        {
            return (Name + " age : " + Age + " - habite à  : " + HomeAddress.ToString());
        }
        //=========================================================================================
        internal static string display(List<Person> people)
        {
            string s = "";
            foreach (Person p in people)
                s += p.ToString() + "\n";
            //
            return s;
        }

        [NonSerialized]
        public string ThisWillNotBeWrittenToTheFile = "because of the [XmlIgnore] attribute."; // DONT WORK
    }

    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return StreetAddress + " (" + City.ToUpper() + ")";
        }
    }





    //#############################################################################################
    // 
    //#############################################################################################








}



