using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Player
    {
        public Inventory MyInventory;
        public Recipe MyRecipe;
        public int myMoney;
        public int myPrice;
        public string MyName;
        public int DailyProfit;
        public int TotalProfit;
        public bool hasMade;

        public Player(string myname)
        {
            MyInventory = new Inventory();
            MyRecipe = new Recipe();
            myMoney = 65;
            myPrice = 6;
            MyName = myname;
            DailyProfit = 0;
            TotalProfit = 0;
            hasMade = false;

        }

        public void UpdateDaily(int NewProfit)
        {
            NewProfit *= myPrice;
            DailyProfit += NewProfit;
            
        }

        public void UpdateTotal(int CashSpent)
        {
            DailyProfit -= CashSpent;
            TotalProfit += DailyProfit;
            
            
        }

        public void ResetDaily()
        {
            DailyProfit = 0;            
            hasMade = false;
        }

        public void MakeLemonade()
        {
            hasMade = true;
        }
    }
       
}