using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Player
    {
        public Inventory MyInventory;
        public Recipe MyRecipe;
        public int MyMoney;
        public double MyPrice;
        public string MyName;

        public Player(string myname)
        {
            MyInventory = new Inventory();
            MyRecipe = new Recipe();
            MyMoney = 100;
            MyPrice = 0.00;
            MyName = myname;

        }
    }
       
}