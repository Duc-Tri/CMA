using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    class Dog : Animal
    {
        public Dog() 
        {
            isAlive = true;
            Legs = 4;
        }


        public Dog(string nomDuChien):base(nomDuChien)
        {
        }
        

        public Dog(string nom, int age) : base(nom)
        {
            this.age = age;
        }


        public void Bark()
        {
            Console.WriteLine("Woarf !");
        }


        public void Aging()
        {
            age++;
        }


        public void Birth()
        {
            isAlive = true;
        }

    } // end class ________________________________________________________________________________

} // end namespace ________________________________________________________________________________
