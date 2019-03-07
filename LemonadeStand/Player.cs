using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Player
    {
        public Inventory MyInventory;
        public Recipe MyRecipe;
        public int myGrubs;
        public int myPrice;
        public string myName;
        public int dailyProfit;
        public int totalProfit;
        public bool hasMade;

        public Player()
        {
            MyInventory = new Inventory();
            MyRecipe = new Recipe();
            myGrubs = 65;
            myPrice = 6;
            dailyProfit = 0;
            totalProfit = 0;
            hasMade = false;

        }

        public void UpdateDaily(int newProfit)
        {
            newProfit *= myPrice;
            dailyProfit += newProfit;
            
        }

        public void UpdateTotal(int cashSpent)
        {
            dailyProfit -= cashSpent;
            totalProfit += dailyProfit;
            
            
        }

        public void ResetDaily()
        {
            dailyProfit = 0;            
            hasMade = false;
        }

        public void MakeLemonade()
        {
            hasMade = true;
        }
    }
       
}