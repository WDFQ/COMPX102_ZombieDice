using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    public class Cup
    {
        List<Die> _diceList;

        public Cup()
        {
            _diceList = new List<Die>();
        } 

        
        public virtual DiceList<>
        {
            get {return _diceList;}
            set {_diceList = value;}
        }
        

        /// <summary>
        /// populates the cup with 6 green dies, 3 red and 4 yellow
        /// </summary>
       private void AddDice()
       {
            for (int i = 0; i < 6; i++)
            {
                GreenDie newGreenDie = new GreenDie();
                diceList.Add(newGreenDie);
            }
            for (int i = 0; i < 3; i++)
            {
                RedDie newRedDie = new RedDie();
                diceList.Add(newRedDie);
            }
            for (int i = 0; i < 4; i++)
            {
                YellowDie newYellowDie = new YellowDie();
                diceList.Add(newYellowDie);
            }
       }

        public List<Die> DrawDice()
        {
            Random rand = new Random();
            List<Die> drawnDice = new List<Die>();

            for (int i = 0; i < 3; i++)
            {
                int diceIndex = rand.Next(diceList.Count);
                drawnDice.Add(diceList[diceIndex]);
                diceList.RemoveAt(diceIndex);
            }

            return drawnDice;
        }

    }
}
