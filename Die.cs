using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    public abstract class Die
    {
        //fields
        protected DiceResult _lastRoll;

        //properties
        public DiceResult LastRoll
        {
            get { return _lastRoll; }
            set { _lastRoll = value; }
        }

        //Constructor
        public Die()
        {
        }

        /// <summary>
        /// Randomly generates an outcome from the list of possible outcomes and returns it
        /// </summary>
        /// <returns>The result of the dice roll</returns>
        public abstract DiceResult Roll();


        /// <summary>
        /// gets the dice color and returns it
        /// </summary>
        /// <returns>dice color</returns>
        public abstract Color GetDiceColor();
       
    }
}
