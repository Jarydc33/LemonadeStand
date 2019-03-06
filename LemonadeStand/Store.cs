using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Store
    {
        public int lemonPrice;
        public int cupPrice;
        public int SugarPrice;
        public int IcePrice;
        public int[] storePrices;
        public int CashSpent;

        public Store()
        {
            storePrices = new int[4];
            lemonPrice = 2;
            storePrices[0] = lemonPrice;
            SugarPrice = 3;
            storePrices[1] = SugarPrice;
            IcePrice = 5;
            storePrices[2] = IcePrice;
            cupPrice = 1;
            storePrices[3] = cupPrice;
            CashSpent = 0;
        }

        public int Cashier(int WhichItem, int TotalCash, int[]MyTotalInventory, int AmountPurchased)
        {
            int StartingCash = TotalCash;
            
            switch (WhichItem)
            {
                case 1:
                    TotalCash -= lemonPrice * AmountPurchased;
                    MyTotalInventory[0] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    break;

                case 2:
                    TotalCash -= SugarPrice * AmountPurchased;
                    MyTotalInventory[1] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    break;
                                   
                case 3:
                    TotalCash -= IcePrice * AmountPurchased;
                    MyTotalInventory[2] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    break;

                case 4:
                    TotalCash -= cupPrice * AmountPurchased;
                    MyTotalInventory[3] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    break;

                case 5:
                    TotalCash -= lemonPrice * AmountPurchased;
                    TotalCash -= SugarPrice * AmountPurchased;
                    TotalCash -= IcePrice * AmountPurchased;
                    TotalCash -= cupPrice * AmountPurchased;

                    if (TotalCash < 0)
                    {
                        return StartingCash;
                    }

                    MyTotalInventory[0] += AmountPurchased;
                    MyTotalInventory[1] += AmountPurchased;
                    MyTotalInventory[2] += AmountPurchased;
                    MyTotalInventory[3] += AmountPurchased;

                    CashSpent = StartingCash - TotalCash;
                    break;                   
            }
                return TotalCash;
        }

        public void CashSpentReset()
        {
            CashSpent = 0;
            
        }

    }
}