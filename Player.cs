using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    public class Player
    {
        //fields
        private bool _isPlayerTurn;
        private int _brainsCount;

        //Properties
        public bool IsPlayerTurn
        {
            get { return _isPlayerTurn; } 
            set {  _isPlayerTurn = value; }
        }
        public int BrainsCount
        {
            get { return _brainsCount; }
            set { _brainsCount = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Player() 
        {
            IsPlayerTurn = false;
            BrainsCount = 0;
        }

    }
}
