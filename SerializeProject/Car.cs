using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeProject
{
    class Car
    {
        private static float MAX_ALLOWED_SPEED = 130;
        private static Int32 total = 0;

        private int id;
        private float speed;
        private string color;
        private string model;

        public float Speed { get { return speed; } set { speed = value; } }
        public string Color { get { return color; } set { color = value; } }
        public string Model { get { return model; } set { model = value; } }

        public Car() : base()
        {
            Console.WriteLine("Constructeur par défaut");
            total++;
            id = total;
            speed = 0;
            color = "bleu";
            model = "2 CV";

        }

        public Car(string col) : this()
        {
            Console.WriteLine("Constructeur avec COL");
        }

        private string modelID
        {
            get
            {
                return "Car#" + id + "[" + model + "]";
            }
        }
        public void start()
        {
            Console.WriteLine(modelID + " démarré");
        }

        public void run(float _speed)
        {
            speed = _speed;
            Console.WriteLine(modelID + " roule à " + speed);
            checkSpeed();
        }


        private bool checkSpeed()
        {
            bool crossed = (speed > MAX_ALLOWED_SPEED);

            Console.WriteLine(crossed ?
                ("LA VITESSE DE " + modelID + " A DÉPASSÉ " + MAX_ALLOWED_SPEED) :
                ("La vitesse de " + modelID + " est dans les limites"));
            //
            return crossed;



        }

    }

}
