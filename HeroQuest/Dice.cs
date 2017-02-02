
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroQuest
{
    /*
    N'oubliezpas,pourgénérerunnombrealéatoire,ilfautinstancierunobjetRandometappelerlaméthodeNextsurl'objet.
    Onluipasseraenparamètrelesbornesdutiragealéatoire.Parexemplepouravoirunnombrealéatoireentre1et6(inclus),ilfautfaire:
    Randomrandom=newRandom(); intresult=random.Next(1,7);
    N'hésitezpasàconserverl'objetrandomcommemembredesclasses,pouréviterd'avoiràleréinstancieràchaquetirage.
    */

    class Dice
    {
        private static Random rand;
        private static Dice _instance;
        public static Dice instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Dice();
                return _instance;
            }
        }

        private Dice()
        {
            rand = new Random((int)DateTime.Now.Ticks);
        }

        //•possèdeuneméthodeRollTheDicequirenvoiunentier
        public int RollTheDice(string mess = "")
        {
            int res = rand.Next(1, 7); // 1..6
            Console.WriteLine("          DICE:RollTheDice pour " + mess + "......" + res);
            return res;
        }
    }

}
