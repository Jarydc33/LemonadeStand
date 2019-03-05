using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Customer
    {
        //public bool WillBuy;
        public int[] Preference; // Ill do a number to determine whether the lemonade is (1) very sweet (2) sweet, (3) sour, (4) very sour ?
        public string[] Opinion;
        public string Name;
        public int HowMany;
        public string CustomerThought;
        double PriceRoof;

        public Customer(int preference, int temppref, double priceRoof, string name)
        {
            Preference = new int[2];
            Opinion = new string[4];
            Preference[0] = preference;
            Preference[1] = temppref;
            PriceRoof = priceRoof;
            Name = name;
            Opinion[0] = " says: This is too sour for me!";
            Opinion[1] = " says: This is too expensive for me!";
            Opinion[2] = " says: Yummy. This is delicious!";
            Opinion[3] = " says: This is too sweet for me!";
            HowMany = 0;
        }

        public void Purchase(int HowSweet, int HowCold, double CurrentPrice, int[] Temperature)
        {
            HowMany = 0;
            if(Temperature[0] > 83)
            {
                HowMany = 1;
            }
            if(CurrentPrice > PriceRoof)
            {
                CustomerThought = Opinion[1];
            }
            else
            {
                switch (HowSweet)
                {
                    case 1:
                        if (Preference[0] == 1 || Preference[0] == 2)
                        {
                            CustomerThought = Opinion[2];
                            HowMany += 2;
                        }
                        else
                        {
                            CustomerThought = Opinion[3];
                            HowMany += 0;
                        }
                        break;

                    case 2:
                        if (Preference[0] == 1 || Preference[0] == 2)
                        {
                            CustomerThought = Opinion[2];
                            HowMany += 2;
                        }
                        else
                        {
                            CustomerThought = Opinion[3];
                            HowMany += 0;
                        }
                        break;

                    case 3:
                        if (Preference[0] == 3 || Preference[0] == 4)
                        {
                            CustomerThought = Opinion[2];
                            HowMany += 2;
                        }
                        else
                        {
                            CustomerThought = Opinion[0];
                            HowMany += 0;
                        }
                        break;

                    case 4:
                        if (Preference[0] == 3 || Preference[0] == 4)
                        {
                            CustomerThought = Opinion[2];
                            HowMany += 2;
                        }
                        else
                        {
                            CustomerThought = Opinion[0];
                            HowMany += 0;
                        }
                        break;
                }
            }
            
        }
    }
}