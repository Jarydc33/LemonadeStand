using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Inventory
    {
        public int Lemons;
        public int Sugar;
        public int Ice;
        public int Cups;
        public int[] TotalInventory;

        public Inventory()
        {
            TotalInventory = new int[4];
            Lemons = 5;
            TotalInventory[0] = Lemons;
            Sugar = 3;
            TotalInventory[1] = Sugar;
            Ice = 3;
            TotalInventory[2] = Ice;
            Cups = 35;
            TotalInventory[3] = Cups;
        }

        public int UpdateInventoryRecipe(int[]Changes)
        {
            if(TotalInventory[0] < Changes[0])
            {
                return 1;
            }
            else if(TotalInventory[1] < Changes[1])
            {
                return 1;
            }
            else if(TotalInventory[2] < Changes[2])
            {
                return 1;
            }
            else
            {
                TotalInventory[0] -= Changes[0];
                TotalInventory[1] -= Changes[1];
                TotalInventory[2] -= Changes[2];
                return 0;
            }
            
        }
        public bool UpdateInventoryGame(int CupChange)
        {            
            if(TotalInventory[3] < CupChange)
            {
                return false;
            }
            TotalInventory[3] -= CupChange;
            return true;
        }
        
    }
}