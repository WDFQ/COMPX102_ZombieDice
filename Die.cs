﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombie_Dice_Jeff_Jia
{
    public abstract class Die
    {
        //fields
        protected string _lastRoll;

        //properties
        public string LastRoll
        {
            get { return _lastRoll; }
            set { _lastRoll = value; }
        }

        //Constructor
        public Die()
        {
        }


        public abstract string Roll();
        public abstract Color GetDiceColor();
       
    }
}
