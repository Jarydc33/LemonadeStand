using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Customer
    {
        public bool WillBuy;
        public int Preference; // Ill do a number to determine whether the lemonade is (1) very sweet (2) sweet, (3) sour, (4) very sour ?
        public int TempPref;
        public int HowMuch;
        public string Name;

        public Customer(int preference, int temppref, string name)
        {
            Preference = preference;
            TempPref = temppref;
            Name = name;
        }

        public int Purchase(int HowSweet, int HowCold)
        {
            if(Preference == HowSweet)
            {
                HowMuch = 1;
                if (TempPref == HowCold)
                {
                    HowMuch = 2;
                    return HowMuch;
                }
                return HowMuch;
            }
            else if(HowSweet > Preference)
            {
                HowMuch = 3;
                if(TempPref == HowCold)
                {
                    HowMuch = 3;//?
                }
            }
            else if (Preference > HowSweet)
            {
                HowMuch = 4;//?
                    if (TempPref == HowCold)
                    {
                        HowMuch = 4;//?
                    }
                {

                }
            }
        }

    }
}