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
        public double VodkaPrice;
        public double IcePrice;
        public double[] StorePrices;

        public Store()
        {
            StorePrices = new double[5];
            LemonPrice = 1.12;
            StorePrices[0] = LemonPrice;
            SugarPrice = 2.25;
            StorePrices[1] = SugarPrice;
            VodkaPrice = 15.00;
            StorePrices[2] = VodkaPrice;
            IcePrice = 1.55;
            StorePrices[3] = IcePrice;
            CupPrice = .15;
            StorePrices[4] = CupPrice;
        }

        public double Cashier(int WhichItem, double TotalCash, int[]MyTotalInventory, int AmountPurchased)
        {
            switch (WhichItem)
            {
                case 1:
                    TotalCash -= LemonPrice;
                    MyTotalInventory[0] += AmountPurchased;
                    return TotalCash;

                case 2:
                    TotalCash -= SugarPrice;
                    MyTotalInventory[1] += AmountPurchased;
                    return TotalCash;

                case 3:
                    TotalCash -= VodkaPrice;
                    MyTotalInventory[2] += AmountPurchased;
                    return TotalCash;

                case 4:
                    TotalCash -= IcePrice;
                    MyTotalInventory[3] += AmountPurchased;
                    return TotalCash;

                case 5:
                    TotalCash -= CupPrice;
                    MyTotalInventory[4] += AmountPurchased;
                    return TotalCash;
            }
            return TotalCash;
        }

    }
}