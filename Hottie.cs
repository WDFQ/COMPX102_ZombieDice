using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    class Hottie : Die
    {
        //fields
        //enum used for dice outcomes
        private DiceResult[] _faces = { DiceResult.Footsteps, DiceResult.Footsteps, DiceResult.Footsteps, DiceResult.Shotgun, DiceResult.Shotgun, DiceResult.Brain };
        private Color _diceColor = Color.Pink;
      



        /// <summary>s
        /// can only get the dice color not set it
        /// </summary>
        public Color DiceColor
        {
            get { return _diceColor; }
        }





        /// <summary>
        /// constructor
        /// </summary>
        public Hottie()
        {
           
        }

        /// <summary>
        /// overrides the roll method from super class
        /// </summary>
        /// <returns>last roll result</returns>
        public override DiceResult Roll()
        {
            Random rand = new Random();
            int result = rand.Next(_faces.Length);  // Random index from 0 to 5
            LastRoll = _faces[result];
            return LastRoll;
        }

        /// <summary>
        /// Returns the color of the die
        /// </summary>
        /// <returns>color</returns>
        public override Color GetDiceColor()
        {
            return DiceColor;
        }
    }
}

