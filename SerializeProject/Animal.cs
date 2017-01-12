using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    public class Animal
    {
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
            Console.WriteLine("je respire");
        }



    } // end class ________________________________________________________________________________

} // end namespace ________________________________________________________________________________
