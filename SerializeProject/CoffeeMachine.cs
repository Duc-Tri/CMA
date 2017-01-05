using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    class CoffeeMachine
    {
        private static Int32 total = 0;

        private int id;

        private int coins;

        public float ex;

        public int ID
        {
            get { return id; }
            set { }
        }

        //=========================================================================================
        public CoffeeMachine()
        {
            total++;
            id = total;
            Console.WriteLine("Constructeur CoffeeMachine#" + id);
        }

        //=========================================================================================
        public void GetCoffee()
        {

        }

        //=========================================================================================
        public void InsertCoin(int coin)
        {

        }

        //=========================================================================================
        public void SelectBeverageSize(int size)
        {

        }

        //=========================================================================================
        private bool IsChangeAvailable()
        {
            return true;
        }

        //=========================================================================================
        private bool IsCoffeeAvailable()
        {
            return true;
        }

        //=========================================================================================
        private void MakeCoffee()
        {
        }

    }
}
