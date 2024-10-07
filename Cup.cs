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
       public void AddDice()
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
            for (int i = 0; i < 3; i++)
            {
                YellowDie newYellowDie = new YellowDie();
                _diceList.Add(newYellowDie);
            }

            Hunk newHunk = new Hunk();
            _diceList.Add(newHunk);
       }

        /// <summary>
        /// Draws dice from the dice list and returns it 
        /// </summary>
        /// <returns></returns>
        public Die DrawDie()
        {
            Random rand = new Random();
            int diceIndex = rand.Next(_diceList.Count);
            Die die = _diceList[diceIndex];
            _diceList.RemoveAt(diceIndex);

            return die;
        }

    }
}
