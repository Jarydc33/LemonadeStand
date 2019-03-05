using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Customer
    {
        //public bool WillBuy;
        public int Preference; // Ill do a number to determine whether the lemonade is (1) very sweet (2) sweet, (3) sour, (4) very sour ?
        public int TempPref;
        public string[] Opinion;
        public string Name;
        public int HowMany;

        public Customer(int preference, int temppref, string name)
        {
            Preference = preference;
            TempPref = temppref;
            Name = name;
            Opinion = new string[3];
            HowMany = 0;
        }

        public string[] Purchase(int HowSweet, int HowCold, double CurrentPrice, int[] Temperature)
        {
            HowMany = 0;
            if(Temperature[0] > 85)
            {
                HowMany = 1;
                Console.WriteLine("Temp test");
            }

            if (CurrentPrice > 10.00)
            {
                Opinion[0] = " says: That is a ridiculous price!";
                Opinion[1] = " I do not want any!";
                Opinion[2] = "" + 0;
                return Opinion;
            }
            else if (Preference == HowSweet)
            {  
                if (TempPref == HowCold)
                {
                    Opinion[0] = " says: The flavor is perfect and so is the temperature!";
                    Opinion[1] = " Ill take " + (HowMany + 3) + "!";
                    Opinion[2] = "" + (HowMany + 3);
                    return Opinion;
                }
                else if(TempPref < HowCold)
                {
                    Opinion[0] = " says: The flavor is good, but it is too cold!";
                    if(CurrentPrice > 1.25)
                    {
                        Opinion[1] = " I would have bought " + (HowMany + 2) + "but I can`t pay more than $1.25 for it. I`ll only have " + (HowMany + 1) + ".";
                        Opinion[2] = "" + HowMany + 1;
                    }
                    else
                    {
                        Opinion[1] = " I`ll take " + (HowMany + 2) +"." ;
                        Opinion[2] = "" + HowMany + 2;
                    }
                    
                    return Opinion;
                }
                else
                {
                    Opinion[0] = " says: The flavor is great but it is far too warm!";

                    if (CurrentPrice > 1.05)
                    {
                        Opinion[1] = " I would have bought " + (HowMany + 1) + ", but I can`t pay more than $1.05 for it.";
                    }
                    else
                    {
                        Opinion[1] = " I`ll only take " + (HowMany + 1) + ".";
                        Opinion[2] = "" + HowMany + 1;
                    }
                    return Opinion;
                }
            }
            else if(HowSweet > Preference)
            {                
                if(TempPref == HowCold)
                {
                    Opinion[0] = " says: The temperature is perfect but it is too sour!";
                    if (CurrentPrice > 1.50)
                    {
                        Opinion[1] = " I would have bought " + (HowMany + 2) + ", but I can`t pay more than $1.50 for it. I`ll only take " + (HowMany + 1) + ".";
                        Opinion[2] = "" + HowMany + 1;
                    }
                    else
                    {
                        Opinion[1] = " I think I`ll take " + (HowMany + 2) + ".";
                        Opinion[2] = "" + HowMany + 2;
                    }
                    return Opinion;
                }
                else if(TempPref < HowCold)
                {
                    Opinion[0] = " says: Way too sour and too cold!";
                    if (CurrentPrice > 1.05)
                    {
                        Opinion[1] = " I would have bought " + (HowMany + 1) + ", but I can`t pay more than $1.05 for it.";
                    }
                    else
                    {
                        Opinion[1] = " I`ll only take " + (HowMany + 1) + ".";
                        Opinion[2] = "" + HowMany + 1;
                    }
                    return Opinion;
                }
                else
                {
                    Opinion[0] = " says: Too sour and too warm. Bleh.";
                    Opinion[1] = " I don`t want any!!";
                    Opinion[2] = "" + 0;
                    return Opinion;
                }
            }
            else if (Preference > HowSweet)
            {
                if (TempPref == HowCold)
                {
                    Opinion[0] = " says: The temperature is perfect but it is too sweet!";
                    if (CurrentPrice > 1.40)
                    {
                        Opinion[1] = " I would have bought " + (HowMany + 2) + ", but I can`t pay more than $1.40 for it. I`ll only take " + (HowMany + 1) + ".";
                        Opinion[2] = "" + HowMany + 1;
                    }
                    else
                    {
                        Opinion[1] = " I`ll take " + (HowMany + 2) + "!";
                        Opinion[2] = "" + HowMany + 2;
                    }
                    return Opinion;
                }
                else if (TempPref < HowCold)
                {
                    Opinion[0] = " says: Way too sweet and too cold!";
                    if (CurrentPrice > 1.13)
                    {
                        Opinion[1] = " I would have bought " + (HowMany + 1) + ", but I can`t pay more than $1.13 for it.";
                    }
                    else
                    {
                        Opinion[1] = " I`ll only take " + (HowMany + 1) + ".";
                        Opinion[2] = "" + HowMany + 1;
                    }
                    return Opinion;
                }
                else
                {
                    Opinion[0] = " says: Too sweet and too warm. Ewwww.";
                    Opinion[1] = " I don`t want any of this nasty stuff!";
                    Opinion[2] = "" + 0;
                    return Opinion;
                }
            }
            return Opinion;
        }

    }
}