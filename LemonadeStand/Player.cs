using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Player
    {
        public Inventory MyInventory;
        public Recipe MyRecipe;
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
            MyMoney = 65;
            Math.Round(MyMoney, 2, MidpointRounding.AwayFromZero);
            MyPrice = 6;
            MyName = myname;
            DailyProfit = 0.00;
            Math.Round(DailyProfit, 1, MidpointRounding.AwayFromZero);
            TotalProfit = 0.00;
            Math.Round(TotalProfit, 1, MidpointRounding.AwayFromZero);
            HasMade = false;

        }

        public void UpdateDaily(int NewProfit)
        {
            NewProfit *= (int)MyPrice;
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