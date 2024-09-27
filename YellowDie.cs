using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    class YellowDie : Die
    {

        private string[] _faces = { "Brain", "Brain", "Footsteps", "Footsteps", "Shotgun", "Shotgun" };
        private Color _diceColor = Color.Yellow;

        public Color DiceColor
        {
            get { return _diceColor; }
        }

        public YellowDie()
        {
        }

        // Implements the Roll method
        public override string Roll()
        {
            Random rand = new Random();
            int result = rand.Next(0, _faces.Length);  // Random index from 0 to 5
            return _faces[result];
        }

        public override Color GetDiceColor()
        {
            return DiceColor;
        }
    }
}
