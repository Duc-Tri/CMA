using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    class Cat:Animal
    {
        private Cat()
        {
            isAlive = true;
            Legs = 4;
        }

        public Cat(string nomDuChat) : base(nomDuChat)
        {
        }

        public Cat(string nom, int age) : base(nom)
        {
            this.age = age;
        }

        public void Meow()
        {
            Console.WriteLine("meow !!!");
        }
    }
}
