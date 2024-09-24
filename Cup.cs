using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    public class Cup
    {
        List<Die> diceList;

        public Cup()
        {
            diceList = new List<Die>();
        } 

        public Die DrawDie()
        {
            Random rand = new Random();
            int result = rand.Next(0, diceList.Count);  // Random index from 0 to 5
            return diceList[result];


        }

    }
}
