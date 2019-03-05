using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Store
    {
        public double LemonPrice;
        public double CupPrice;
        public double SugarPrice;
        public double IcePrice;
        public double[] StorePrices;
        public double CashSpent;

        public Store()
        {
            StorePrices = new double[4];
            LemonPrice = 1.12;
            StorePrices[0] = LemonPrice;
            SugarPrice = 2.25;
            StorePrices[1] = SugarPrice;
            IcePrice = 1.55;
            StorePrices[2] = IcePrice;
            CupPrice = .15;
            StorePrices[3] = CupPrice;
            CashSpent = 0;
        }

        public double Cashier(int WhichItem, double TotalCash, int[]MyTotalInventory, int AmountPurchased)
        {
            double StartingCash = TotalCash;
            switch (WhichItem)
            {
                case 1:
                    TotalCash -= LemonPrice * AmountPurchased;
                    MyTotalInventory[0] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    return TotalCash;

                case 2:
                    TotalCash -= SugarPrice * AmountPurchased;
                    MyTotalInventory[1] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    return TotalCash;
                                   
                case 3:
                    TotalCash -= IcePrice * AmountPurchased;
                    MyTotalInventory[2] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    return TotalCash;

                case 4:
                    TotalCash -= CupPrice * AmountPurchased;
                    MyTotalInventory[3] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    return TotalCash;

                case 5:
                    TotalCash -= LemonPrice * AmountPurchased;
                    MyTotalInventory[0] += AmountPurchased;

                    TotalCash -= SugarPrice * AmountPurchased;
                    MyTotalInventory[1] += AmountPurchased;

                    TotalCash -= IcePrice * AmountPurchased;
                    MyTotalInventory[2] += AmountPurchased;

                    TotalCash -= CupPrice * AmountPurchased;
                    MyTotalInventory[3] += AmountPurchased;
                    CashSpent = StartingCash - TotalCash;
                    return TotalCash;                    
            }
            
            return TotalCash;
        }

    }
}