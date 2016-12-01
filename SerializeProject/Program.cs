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
            Console.ReadKey();
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
