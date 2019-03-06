using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Customer
    {
        public int preference;
        public string[] opinion;
        public string name;
        public int howMany;
        public string customerThought;
        public int priceRoof;

        public Customer(int preference, int priceRoof, string name)
        {            
            opinion = new string[5];
            this.preference = preference;
            this.priceRoof = priceRoof;
            this.name = name;
            opinion[0] = " says: This is too banana-y for me!";
            opinion[1] = " says: This is too expensive for me!";
            opinion[2] = " says: Yummy. This is delicious!";
            opinion[3] = " says: This is too bug-y for me!";
            opinion[4] = " says: You didn`t even put ice in this!";
        }

        public void Purchase(int howSweet, int howCold, double currentPrice, int temperature)
        {
            howMany = 0;
            if(temperature > 85)
            {
                howMany = 1;
            }
            else if(temperature > 100)
            {
                howMany = 2;
            }

            if(howCold == 0)
            {
                customerThought = opinion[4];
                howMany = 0;
            }
            else if(currentPrice > priceRoof)
            {
                customerThought = opinion[1];
                howMany = 0;
            }
            else
            {
                switch (howSweet)
                {
                    case 1:
                        if (preference == 1 || preference == 2)
                        {
                            customerThought = opinion[2];
                            howMany += 2;
                        }
                        else
                        {
                            customerThought = opinion[3];
                            howMany += 0;
                        }
                        break;

                    case 2:
                        if (preference == 1 || preference == 2)
                        {
                            customerThought = opinion[2];
                            howMany += 2;
                        }
                        else
                        {
                            customerThought = opinion[3];
                            howMany += 0;
                        }
                        break;

                    case 3:
                        if (preference == 3 || preference == 4)
                        {
                            customerThought = opinion[2];
                            howMany += 2;
                        }
                        else
                        {
                            customerThought = opinion[0];
                            howMany += 0;
                        }
                        break;

                    case 4:
                        if (preference == 3 || preference == 4)
                        {
                            customerThought = opinion[2];
                            howMany += 2;
                        }
                        else
                        {
                            customerThought = opinion[0];
                            howMany += 0;
                        }
                        break;
                }
            }
            
        }
    }
}