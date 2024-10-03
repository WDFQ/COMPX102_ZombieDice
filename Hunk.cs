using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    class Hunk : Die
    {

        private string[] _faces = { "Feet", "Feet", "Shotgun", "Shotgun", "DoubleShotgun", "DoubleBrain" };
        private Color _diceColor = Color.Black;

        public Color DiceColor
        {
            get { return _diceColor; }
        }


        public Hunk()
        {
        }

        // Implements the Roll method
        public override string Roll()
        {
            Random rand = new Random();
            int result = rand.Next(_faces.Length);  // Random index from 0 to 5
            LastRoll = _faces[result];
            return LastRoll;
        }

        public override Color GetDiceColor()
        {
            return DiceColor;
        }
    }
}
