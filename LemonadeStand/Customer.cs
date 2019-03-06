using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Customer
    {
        public int Preference;
        public string[] Opinion;
        public string Name;
        public int howMany;
        public string CustomerThought;
        public int PriceRoof;

        public Customer(int preference, int priceRoof, string name)
        {            
            Opinion = new string[5];
            Preference = preference;
            PriceRoof = priceRoof;
            Name = name;
            Opinion[0] = " says: This is too banana-y for me!";
            Opinion[1] = " says: This is too expensive for me!";
            Opinion[2] = " says: Yummy. This is delicious!";
            Opinion[3] = " says: This is too bug-y for me!";
            Opinion[4] = " says: You didn`t even put ice in this!";
        }

        public void Purchase(int HowSweet, int HowCold, double CurrentPrice, int Temperature)
        {
            howMany = 0;
            if(Temperature > 85)
            {
                howMany = 1;
            }
            else if(Temperature > 100)
            {
                howMany = 2;
            }

            if(HowCold == 0)
            {
                CustomerThought = Opinion[4];
                howMany = 0;
            }
            else if(CurrentPrice > PriceRoof)
            {
                CustomerThought = Opinion[1];
                howMany = 0;
            }
            else
            {
                switch (HowSweet)
                {
                    case 1:
                        if (Preference == 1 || Preference == 2)
                        {
                            CustomerThought = Opinion[2];
                            howMany += 2;
                        }
                        else
                        {
                            CustomerThought = Opinion[3];
                            howMany += 0;
                        }
                        break;

                    case 2:
                        if (Preference == 1 || Preference == 2)
                        {
                            CustomerThought = Opinion[2];
                            howMany += 2;
                        }
                        else
                        {
                            CustomerThought = Opinion[3];
                            howMany += 0;
                        }
                        break;

                    case 3:
                        if (Preference == 3 || Preference == 4)
                        {
                            CustomerThought = Opinion[2];
                            howMany += 2;
                        }
                        else
                        {
                            CustomerThought = Opinion[0];
                            howMany += 0;
                        }
                        break;

                    case 4:
                        if (Preference == 3 || Preference == 4)
                        {
                            CustomerThought = Opinion[2];
                            howMany += 2;
                        }
                        else
                        {
                            CustomerThought = Opinion[0];
                            howMany += 0;
                        }
                        break;
                }
            }
            
        }
    }
}