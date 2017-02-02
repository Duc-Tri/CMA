using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroQuest
{
    class HeavyMonster : LittleMonster
    {
        /*
        L'attaquedumonstredifficileestlamêmequecelledumonstrefacile,saufqu'ilenchaineavecunsortmagique.

        Unjetdedéestréaliséetsicejetestdifférentde6alorslehérosperçoitdesdommageséquivalentàlavaleurdudémultipliéparunevaleurforfaitaire,disons5.
        */

        public HeavyMonster():base()
        {
            //Console.WriteLine("HEAVYMONSTER:CONSTRUCTEUR");
        }

        public override void Attack(Player player)
        {
            Console.Write("GROS ");

            base.Attack(player);
            //.........................
            int déSortMagique = Dice.instance.RollTheDice("sort magique");
            if(déSortMagique!=6)
            {
                Console.WriteLine("....... sort magique réussi "+déSortMagique);
                player.TakeDamage(déSortMagique * 5);
            }
        }
    }
}
