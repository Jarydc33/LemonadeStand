using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Player
    {
        public Inventory MyInventory;
        public Recipe MyRecipe;
        public MakeLemonade MyLemonade;
        public double MyMoney;
        public double MyPrice;
        public string MyName;
        public double DailyProfit;
        public double TotalProfit;
        public bool HasMade;

        public Player(string myname)
        {
            MyInventory = new Inventory();
            MyRecipe = new Recipe();
            MyLemonade = new MakeLemonade();
            MyMoney = 100;
            MyPrice = 0.00;
            MyName = myname;
            DailyProfit = 0.00;
            TotalProfit = 0.00;
            HasMade = false;

        }

        public void UpdateDaily(int NewProfit)
        {
            DailyProfit += NewProfit;
            
            
        }

        public void UpdateTotal(double CashSpent)
        {
            DailyProfit -= CashSpent;
            TotalProfit += DailyProfit;
            
            
        }

        public void ResetDaily()
        {
            DailyProfit = 0.00;
            HasMade = false;
        }

        public void MakeLemonade()
        {
            HasMade = true;
        }
    }
       
}