using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Store
    {
        public int lemonPrice;
        public int cupPrice;
        public int sugarPrice;
        public int icePrice;
        public int[] storePrices;
        public int cashSpent;

        public Store()
        {
            storePrices = new int[4];
            lemonPrice = 2;
            storePrices[0] = lemonPrice;
            sugarPrice = 3;
            storePrices[1] = sugarPrice;
            icePrice = 5;
            storePrices[2] = icePrice;
            cupPrice = 1;
            storePrices[3] = cupPrice;
            cashSpent = 0;
        }

        public int Cashier(int whichItem, int totalCash, int[]myTotalInventory, int amountPurchased)
        {
            int startingCash = totalCash;
            
            switch (whichItem)
            {
                case 1:
                    totalCash -= lemonPrice * amountPurchased;
                    myTotalInventory[0] += amountPurchased;
                    cashSpent = startingCash - totalCash;
                    break;

                case 2:
                    totalCash -= sugarPrice * amountPurchased;
                    myTotalInventory[1] += amountPurchased;
                    cashSpent = startingCash - totalCash;
                    break;
                                   
                case 3:
                    totalCash -= icePrice * amountPurchased;
                    myTotalInventory[2] += amountPurchased;
                    cashSpent = startingCash - totalCash;
                    break;

                case 4:
                    totalCash -= cupPrice * amountPurchased;
                    myTotalInventory[3] += amountPurchased;
                    cashSpent = startingCash - totalCash;
                    break;

                case 5:
                    totalCash -= lemonPrice * amountPurchased;
                    totalCash -= sugarPrice * amountPurchased;
                    totalCash -= icePrice * amountPurchased;
                    totalCash -= cupPrice * amountPurchased;

                    if (totalCash < 0)
                    {
                        return startingCash;
                    }

                    myTotalInventory[0] += amountPurchased;
                    myTotalInventory[1] += amountPurchased;
                    myTotalInventory[2] += amountPurchased;
                    myTotalInventory[3] += amountPurchased;

                    cashSpent = startingCash - totalCash;
                    break;                   
            }
                return totalCash;
        }

        public void CashSpentReset()
        {
            cashSpent = 0;
            
        }

    }
}