using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Inventory
    {
        public int Lemons;
        public int Sugar;
        public int Vodka;
        public int Ice;
        public int Cups;
        public int[] TotalInventory;

        public Inventory()
        {
            TotalInventory = new int[5];
            Lemons = 0;
            TotalInventory[0] = Lemons;
            Sugar = 0;
            TotalInventory[1] = Sugar;
            Vodka = 0;
            TotalInventory[2] = Vodka;
            Ice = 0;
            TotalInventory[3] = Ice;
            Cups = 0;
            TotalInventory[4] = Cups;
        }
        
    }
}