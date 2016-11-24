using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //testSerialization();
            testDate();
            Console.ReadKey();
        }
        
        //=========================================================================================
        private static void testDate()
        {
            Console.WriteLine(MyDate.Jour(3));
            Console.WriteLine(MyDate.getWeekDay(24,11,2016));
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
