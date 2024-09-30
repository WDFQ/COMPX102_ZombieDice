using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    public class Cup
    {
        public List<Die> _diceList;

        public Cup()
        {
            _diceList = new List<Die>();
        } 


        /// <summary>
        /// populates the cup with 6 green dies, 3 red and 4 yellow
        /// </summary>
       public void AddDices()
       {
            for (int i = 0; i < 6; i++)
            {
                GreenDie newGreenDie = new GreenDie();
                _diceList.Add(newGreenDie);
            }
            for (int i = 0; i < 3; i++)
            {
                RedDie newRedDie = new RedDie();
                _diceList.Add(newRedDie);
            }
            for (int i = 0; i < 4; i++)
            {
                YellowDie newYellowDie = new YellowDie();
                _diceList.Add(newYellowDie);
            }
       }

        /// <summary>
        /// Draws 3 dice from the dice list and returns it in a list of 3 dice
        /// </summary>
        /// <returns></returns>
        public Die DrawDie()
        {
            Random rand = new Random();
            

            int diceIndex = rand.Next(_diceList.Count);
           

            return _diceList[diceIndex];
        }

    }
}
