using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    public class Animal
    {
        private bool isalive;

        public bool isAlive
        {
            get { return isalive; }
            set { isalive = value; }
        }

        protected int age;

        public string name;

        private int legs;

        public int Legs
        {
            get { return legs; }

            set
            {
                if (value >= 0 && value <= 1000)
                    legs = value;
            }
        }

        public void Breath()
        {
            Console.WriteLine(name + " respire !");
        }

        public Animal(string nom)
        {
            name = nom;
        }
        public Animal()
        {
            Console.WriteLine("CONSTRUCTEUR PAR DEFAUT ANIMAL !!!");

        }


    } // end class ________________________________________________________________________________

} // end namespace ________________________________________________________________________________
