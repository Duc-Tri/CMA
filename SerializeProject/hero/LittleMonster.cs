using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroQuest
{
    /*
    •possèdeégalementuneméthodeAttack
    •possèdeunepropriétéenlectureseulequiencapsulelefaitdesavoirsilemonstreestvivant
    */
    class LittleMonster
    {
        private bool _vivant;

        public bool estVivant
        {
            get { return _vivant; }
            set { _vivant = value; }
        }

        public LittleMonster()
        {
            //Console.WriteLine("LITTLEMONSTER:CONSTRUCTEUR");

            _vivant = true;
        }

        public virtual void Attack(Player player)
        {
            Console.WriteLine(" monstre Attack ");

            int déPlayer = Dice.instance.RollTheDice("joueur");
            int déMonster = Dice.instance.RollTheDice("monstre");
            if (déMonster>déPlayer)
            {
                player.TakeDamage();
            }
        }

    }
}
