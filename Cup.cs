using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    public class Cup
    {   //fields
        //list holds all dice that are going to be played
        public List<Die> _diceList;

        /// <summary>
        /// constructor
        /// </summary>
        public Cup()
        {
            //initilises the list
            _diceList = new List<Die>();
        } 


        /// <summary>
        /// populates the cup with 6 green dies, 3 red, 3 yellow and 1 hunk die
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
        /// Draws random die from the dice list and returns it 
        /// </summary>
        /// <returns></returns>
        public Die DrawDie()
        {
            Random rand = new Random();
            int diceIndex = rand.Next(_diceList.Count);
            Die die = _diceList[diceIndex]; //set the chosen die to a die variable to be returned
            _diceList.RemoveAt(diceIndex);  //remove the chosen die from the list

            return die; //return the chosen die variable
        }

    }
}
