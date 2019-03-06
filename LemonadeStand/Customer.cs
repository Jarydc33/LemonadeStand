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
            Opinion = new string[5];
            Preference[0] = preference;
            Preference[1] = temppref;
            PriceRoof = priceRoof;
            Name = name;
            Opinion[0] = " says: This is too sour for me!";
            Opinion[1] = " says: This is too expensive for me!";
            Opinion[2] = " says: Yummy. This is delicious!";
            Opinion[3] = " says: This is too sweet for me!";
            Opinion[4] = " says: You didn`t even put ice in this!";
        }

        public void Purchase(int HowSweet, int HowCold, double CurrentPrice, int[] Temperature)
        {
            HowMany = 0;
            if(Temperature[0] > 85)
            {
                HowMany = 1;
                Console.WriteLine("Hit above 83");
            }
            else if(Temperature[0] > 100)
            {
                HowMany = 2;
                Console.WriteLine("Hit above 100!");
            }

            if(HowCold == 0)
            {
                CustomerThought = Opinion[1];
            }
            else if(CurrentPrice > PriceRoof)
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
                            Console.WriteLine(HowMany);
                        }
                        else
                        {
                            CustomerThought = Opinion[3];
                            HowMany += 0;
                            Console.WriteLine(HowMany);
                        }
                        break;

                    case 2:
                        if (Preference[0] == 1 || Preference[0] == 2)
                        {
                            CustomerThought = Opinion[2];
                            HowMany += 2;
                            Console.WriteLine(HowMany);
                        }
                        else
                        {
                            CustomerThought = Opinion[3];
                            HowMany += 0;
                            Console.WriteLine(HowMany);
                        }
                        break;

                    case 3:
                        if (Preference[0] == 3 || Preference[0] == 4)
                        {
                            CustomerThought = Opinion[2];
                            HowMany += 2;
                            Console.WriteLine(HowMany);
                        }
                        else
                        {
                            CustomerThought = Opinion[0];
                            HowMany += 0;
                            Console.WriteLine(HowMany);
                        }
                        break;

                    case 4:
                        if (Preference[0] == 3 || Preference[0] == 4)
                        {
                            CustomerThought = Opinion[2];
                            HowMany += 2;
                            Console.WriteLine(HowMany);
                        }
                        else
                        {
                            CustomerThought = Opinion[0];
                            HowMany += 0;
                            Console.WriteLine(HowMany);
                        }
                        break;
                }
            }
            
        }
    }
}