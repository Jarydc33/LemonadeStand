using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Inventory
    {
        public int bananas;
        public int bugs;
        public int ice;
        public int cups;
        public int[] totalInventory;

        public Inventory()
        {
            totalInventory = new int[4];
            bananas = 5;
            totalInventory[0] = bananas;
            bugs = 3;
            totalInventory[1] = bugs;
            ice = 3;
            totalInventory[2] = ice;
            cups = 35;
            totalInventory[3] = cups;
        }

        public int UpdateInventoryRecipe(int[]changes)
        {
            if(totalInventory[0] < changes[0])
            {
                return 1;
            }
            else if(totalInventory[1] < changes[1])
            {
                return 1;
            }
            else if(totalInventory[2] < changes[2])
            {
                return 1;
            }
            else
            {
                totalInventory[0] -= changes[0];
                totalInventory[1] -= changes[1];
                totalInventory[2] -= changes[2];
                return 0;
            }
            
        }
        public bool UpdateInventoryGame(int cupChange)
        {            
            if(totalInventory[3] < cupChange)
            {
                return false;
            }
            totalInventory[3] -= cupChange;
            return true;
        }
        
    }
}