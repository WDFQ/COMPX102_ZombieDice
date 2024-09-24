using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    class YellowDie : Die
    {

        private string[] Faces = { "Brain", "Brain", "Footsteps", "Footsteps", "Shotgun", "Shotgun" };

        public YellowDie()
        {
        }

        // Implements the Roll method
        public override string Roll()
        {
            Random rand = new Random();
            int result = rand.Next(0, Faces.Length);  // Random index from 0 to 5
            return Faces[result];
        }
    }
}
