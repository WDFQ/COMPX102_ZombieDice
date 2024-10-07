using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    class GreenDie : Die
    {
        //fields
        //enum used for dice outcomes
        private DiceResult[] _faces = { DiceResult.Brain, DiceResult.Brain, DiceResult.Brain, DiceResult.Footsteps, DiceResult.Footsteps, DiceResult.Shotgun };
        private Color _diceColor = Color.Green;

        /// <summary>
        /// can only get the dice color not set it
        /// </summary>
        public Color DiceColor
        {
            get { return _diceColor; }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public GreenDie()
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
