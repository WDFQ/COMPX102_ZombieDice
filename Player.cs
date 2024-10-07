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
        private int _turnBrainCount;
        private int _turnShotgunCount;



        //Properties

        public int TurnBrainCount
        {
            get { return _turnBrainCount; }
            set { _turnBrainCount = value; }
        }

        public int TurnShotgunCount
        {
            get { return _turnShotgunCount; }
            set { _turnShotgunCount = value; }
        }
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
            TurnBrainCount = 0;
            TurnShotgunCount = 0;
        }

    }
}
