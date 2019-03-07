using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Inventory
    {
        public Bananas MyBananas;
        public Bugs MyBugs;
        public Ice MyIce;
        public Cups MyCups;
        public int[] totalInventory;

        public Inventory()
        {
            totalInventory = new int[4];
            MyBananas = new Bananas(5);
            MyBugs = new Bugs(3);
            MyIce = new Ice(3);
            MyCups = new Cups(35);

            totalInventory[0] = MyBananas.quantity;
            totalInventory[1] = MyBugs.quantity;
            totalInventory[2] = MyIce.quantity;
            totalInventory[3] = MyCups.quantity;
        }

        public int UpdateInventoryRecipe(int[]changes)
        {
            for(int i = 0; i < totalInventory.Length - 1; i++)
            {
                if(totalInventory[i] < changes[i])
                {
                    return 1;
                }
            }
            totalInventory[0] -= changes[0];
            totalInventory[1] -= changes[1];
            totalInventory[2] -= changes[2];
            return 0;  
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