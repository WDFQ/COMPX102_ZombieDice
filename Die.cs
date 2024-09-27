using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    public abstract class Die
    {


        //Constructor
        public Die()
        {
        }


        public abstract string Roll();
        public abstract Color GetDiceColor();
       
    }
}
