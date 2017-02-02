using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroQuest
{

    /*
    •possèdeunepropriétéenlectureseulequicontientlespointsdevies;ceux-cisontinitialisésdansleconstructeur.
    •possèdeunepropriétéenlectureseulepermettantdesavoirsilejoueurestvivant,etencapsulelenombredepointsdevie.
    •possèdeuneméthodeAttack,prenantenparamètreunmonstre
    •possèdeuneméthodeTakeDamagequiprendenparamètreunentieraveclavaleurdesdégâtssubits
    */
    class Player
    {
        private int _pointsDeVie;

        public int pointsDeVie { get { return _pointsDeVie; } }

        public virtual bool estVivant { get { return _pointsDeVie > 0; } }

        private const int MAX_VIE = 150;

        public int monstresFacilesTués;
        public int monstresDifficilesTués;
        public int points;

        public Player()
        {
            _pointsDeVie = MAX_VIE;
            points = 0;
            monstresFacilesTués = 0;
            monstresDifficilesTués = 0;
            //Console.WriteLine("PLAYER:CONSTRUCTEUR");
        }

        /*
        Uneattaqueduhérossurunmonstreconsisteenunjetdedédesdeuxprotagonistes.
        Siledéduhérosestsupérieurouégalaudédumonstre,alorscelui - ciestvaincu.
        Sinon,riennesepasseetc'estautourdumonstred'attaquer.
        */
        public void Attack(LittleMonster monstre)
        {
            Console.WriteLine("PLAYER:Attack ");

            int déPlayer = Dice.instance.RollTheDice("joueur");
            int déMonster = Dice.instance.RollTheDice("monstre");
            if (déPlayer >= déMonster)
            {
                Console.WriteLine(".....le joueur a vaincu le monstre !!!");
                monstre.estVivant = false;
                //Chaquemonstrefaciletuérapporte1point,chaquemonstredifficiletuéenrapporte2.
                if (monstre is HeavyMonster)
                {
                    points += 2;
                    monstresDifficilesTués++;
                }
                else
                {
                    points++;
                    monstresFacilesTués++;
                }
            }
        }

        private const int FORFAIT_DAMAGE = 10;
        public void TakeDamage()
        {
            /*
            Anoterquelorsquelehérossubitdesdégâts,sonboucliersedéclencheavecunnouveaujetdedé.
            Sicedernierestinférieurouégalà2(donc2chancessur6),alorslehérosneperçoitpasdedégâts.
            Lecascontraire,sespointsdeviesontdiminuésd'unevaleurforfaitaire,disons10pointsdevie.
            */
            int déBouclier = Dice.instance.RollTheDice();
            if (déBouclier > 2)
            {
                //if (damage >= 0)
                enleverVie(FORFAIT_DAMAGE);
            }
        }

        public void TakeDamage(int damage)
        {
            enleverVie(damage);
        }


        private void enleverVie(int d)
        {
            _pointsDeVie -= d;
            Console.WriteLine("le joueur perd " + d + " points de vie, reste:" + _pointsDeVie);
        }



    }
}
