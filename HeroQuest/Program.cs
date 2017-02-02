using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);

            /*
            Unmonstrealéatoirearrive,lehérosattaquelemonstre; puissilemonstreasurvécuilattaqueàsontourlehérosetcecijusqu'àcequemorts'ensuive(etmorts’ensuivra).
       
            L'attaquedumonstrefacilesurlehérosestsimilaire,maisàladifférencequelejetdumonstredoitêtrestrictementsupérieuraujetduhéros.
            */
            Player monPlayer = new Player();
            do
            {
                LittleMonster monMonstre;
                monMonstre = (rand.Next() % 2 == 0) ? new LittleMonster() : new HeavyMonster();

                do
                {
                    monPlayer.Attack(monMonstre);
                    if (monMonstre.estVivant)
                        monMonstre.Attack(monPlayer);
                }
                while (monPlayer.estVivant && monMonstre.estVivant);

            }
            while (monPlayer.estVivant);

            Console.WriteLine("AVANT DE périr, il a tué " + monPlayer.monstresFacilesTués + " monstres faciles, " + //
                monPlayer.monstresDifficilesTués + " monstres difficiles, et accumulé " + //
                monPlayer.points + " points en or !");
            //-------------------------------
            Console.ReadKey();
        }
    }
}
