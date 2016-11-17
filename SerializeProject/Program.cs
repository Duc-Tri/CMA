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
            Print();
            testSerialization();
            Console.ReadKey();
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


            // List<Person> people = GetListOfPeople();
            XmlSerialization.WriteToXmlFile<Person>("person.txt", person);
            //XmlSerialization.WriteToXmlFile<List<People>>("C:\people.txt", people);

            // Then in some other function.
            person = XmlSerialization.ReadFromXmlFile<Person>("person.txt");
            //List<Person> people = XmlSerialization.ReadFromXmlFile<List<Person>>("C:\people.txt");

            Console.WriteLine(person.ToString());
        }

        static void Print()
        {
            Console.WriteLine("coucou");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age = 20;
        public Address HomeAddress { get; set; }
        private string _thisWillNotGetWrittenToTheFile = "because it is not public.";

        internal string ToString()
        {
            return (Name + " age:" + Age + " habite:" + HomeAddress.ToString());
        }

        [NonSerialized]
        public string ThisWillNotBeWrittenToTheFile = "because of the [XmlIgnore] attribute.";
    }

    public class Address
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return StreetAddress + " - " + City.ToUpper();
        }
    }

}
