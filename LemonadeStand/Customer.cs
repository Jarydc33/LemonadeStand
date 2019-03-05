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
        public string[] Opinion;
        public string Name;

        public Customer(int preference, int temppref, string name)
        {
            Preference = preference;
            TempPref = temppref;
            Name = name;
            Opinion = new string[2];
        }

        public string[] Purchase(int HowSweet, int HowCold)
        {
            if(Preference == HowSweet)
            {               
                if (TempPref == HowCold)
                {
                    Opinion[0] = " says: The flavor is perfect and so is the temperature!";
                    Opinion[1] = " Ill take three";
                    return Opinion;
                }
                else if(TempPref < HowCold)
                {
                    Opinion[0] = " says: The flavor is good, but it is too cold!";
                    Opinion[1] = " I`ll only take one.";
                    return Opinion;
                }
                else
                {
                    Opinion[0] = " says: The flavor is great but it is far too warm!";
                    Opinion[2] = " I`ll only have one.";
                    return Opinion;
                }
            }
            else if(HowSweet > Preference)
            {                
                if(TempPref == HowCold)
                {
                    Opinion[0] = " says: The temperature is perfect but it is too sour!";
                    Opinion[1] = " I think I`ll have two.";
                    return Opinion;
                }
                else if(TempPref < HowCold)
                {
                    Opinion[0] = " says: Way too sour and too cold!";
                    Opinion[1] = " I only want one.";
                    return Opinion;
                }
                else
                {
                    Opinion[0] = " says: Too sour and too warm. Bleh.";
                    Opinion[1] = " I don`t want any!!";
                    return Opinion;
                }
            }
            else if (Preference > HowSweet)
            {
                if (TempPref == HowCold)
                {
                    Opinion[0] = " says: The temperature is perfect but it is too sweet!";
                    Opinion[1] = " I will take two.";
                    return Opinion;
                }
                else if (TempPref < HowCold)
                {
                    Opinion[0] = " says: Way too sweet and too cold!";
                    Opinion[1] = " I only want one.";
                    return Opinion;
                }
                else
                {
                    Opinion[0] = " says: Too sweet and too warm. Ewwww.";
                    Opinion[1] = " I don`t want any of this nasty stuff!";
                    return Opinion;
                }
            }
            return Opinion;
        }

    }
}