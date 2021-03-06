﻿

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

        public Customer(int newPreference, int newPriceRoof, string newName)
        {            
            opinion = new string[5];
            preference = newPreference;
            priceRoof = newPriceRoof;
            name = newName;
            opinion[0] = " says: This is too banana-y for me!";
            opinion[1] = " says: This is too expensive for me!";
            opinion[2] = " says: Yummy. This is delicious!";
            opinion[3] = " says: This is too bug-y for me!";
            opinion[4] = " says: You didn`t even put ice in this!";
        }

        public void determineBaseWeather(int temperature)
        {
            howMany = 0;
            if (temperature > 32)
            {
                howMany = 1;
            }
            else if (temperature > 40)
            {
                howMany = 2;
            }
        }

        public bool ensureIceAmount(int howCold, int currentPrice)
        {
            bool hasIce;
            if (howCold == 0)
            {
                customerThought = opinion[4];
                howMany = 0;
                hasIce = false;
                return hasIce;
            }
            else
            {
                hasIce = true;
                return hasIce;
            }
        }

        public bool ensurePrice(int currentPrice)
        {
            bool rightPrice;
            if(currentPrice > priceRoof)
            {
                customerThought = opinion[1];
                howMany = 0;
                rightPrice = false;
                return rightPrice;
            }
            rightPrice = true;
            return rightPrice;
        }

        public void makePurchase(int howSweet, int howCold, int currentPrice, int temperature)
        {
            determineBaseWeather(temperature);
            bool rightPrice = ensurePrice(currentPrice);
            bool hasIce = ensureIceAmount(howCold, currentPrice);            

            if(hasIce && rightPrice)
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