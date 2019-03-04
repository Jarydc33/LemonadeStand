using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Customer
    {
        public bool WillBuy;
        public int Preference; // Ill do a number to determine whether the lemonade is (1) very sweet (2) sweet, (3) sour, (4) very sour ?
        public int HowMuch;

        public Customer(int preference, bool willbuy)
        {
            Preference = preference;
            WillBuy = willbuy;
        }

        public void Purchase()
        {
            if (WillBuy)
            {

            }
            else
            {

            }
        }

    }
}