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

        public Player(string myname)
        {
            MyInventory = new Inventory();
            MyRecipe = new Recipe();
            MyMoney = 100;
            MyPrice = 0.00;
            MyName = myname;
            DailyProfit = 0.00;
            TotalProfit = 0.00;

        }

        public void UpdateDaily(int NewProfit)
        {
            DailyProfit += NewProfit;
        }

        public void UpdateTotal()
        {
            TotalProfit += DailyProfit;
            DailyProfit = 0.00;
        }
    }
       
}