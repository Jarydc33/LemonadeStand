using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class MakeLemonade
    {
        public bool HasMade;

        public MakeLemonade()
        {
            HasMade = false;
        }

        public void MakingNow()
        {
            HasMade = true;
        }
    }
}
