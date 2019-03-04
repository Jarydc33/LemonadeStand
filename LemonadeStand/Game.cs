using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Game
    {
        public UserInterface UserInterface;
        public Player MyPlayer;
        public Store GameStore;
        public Customer Russian;
        public Customer American;
        public Customer Duck;
        public Customer Thor;
        public string Name;
        public int counter;
        public Day Day1;
        public Day Day2;
        public Day Day3;
        public Day Day4;
        public Day Day5;
        public Day Day6;
        public Day Day7;

        public Game()
        {
            UserInterface = new UserInterface();
            GameStore = new Store();
            Russian = new Customer(4, false);
            American = new Customer(1, true);
            Duck = new Customer(2, false);
            Thor = new Customer(3, true);
            counter = 0;
            //Day1 = new Day(7,1);
            //Day2 = new Day(6,2);
            //Day3 = new Day(5,3);
            //Day4 = new Day(4,4);
            //Day5 = new Day(3,5);
            //Day6 = new Day(2,6);
            //Day7 = new Day(1,7);
            Name = UserInterface.Welcome();
            MyPlayer = new Player(Name);
            GamePlay();
        }

        public void GamePlay()
        {
            string WhatNext =  UserInterface.MainMenu(Name);

            switch (WhatNext)
            {
                case "daily":
                    int[] temp = DetermineDay("daily");
                    UserInterface.OutputDaily(temp[0]);
                    GamePlay();
                    break;

                case "weekly":
                    int[] forecast = DetermineDay("weekly");
                    UserInterface.OutputWeekly(forecast);
                    GamePlay();
                    break;

                case "inventory":
                    UserInterface.ViewInventory(MyPlayer.MyInventory.TotalInventory, MyPlayer.MyMoney);
                    GamePlay();
                    break;

                case "store":
                    string UserInput = UserInterface.StorePrices(GameStore.StorePrices);
                    int AmountPurchased = UserInterface.PurchaseAmount();
                    PurchaseItems(UserInput, AmountPurchased);
                    UserInterface.ViewInventory(MyPlayer.MyInventory.TotalInventory, MyPlayer.MyMoney);
                    GamePlay();
                    break;

                case "start":

                    break;

                default:
                    UserInterface.DefaultResponse();
                    GamePlay();
                    break;
            }
        }

        public int[] DetermineDay(string which)
        {
            switch (counter)
            {
                case 0:
                    //need to increase counter once day two starts
                    if(which == "daily")
                    {
                        Day1 = new Day(7, 1);
                        return Day1.temp;
                    }
                    else
                    {
                        return Day1.SevenDay;
                    }
                case 1:
                    if (which == "daily")
                    {
                        Day2 = new Day(6, 2);
                        return Day2.temp;
                    }
                    else
                    {
                        return Day2.SevenDay;
                    }

                case 2:
                    if (which == "daily")
                    {
                        Day3 = new Day(5, 3);
                        return Day3.temp;
                    }
                    else
                    {
                        return Day3.SevenDay;
                    }

                case 3:
                    if (which == "daily")
                    {
                        Day4 = new Day(4, 4);
                        return Day4.temp;
                    }
                    else
                    {
                        return Day4.SevenDay;
                    }

                case 4:
                    if (which == "daily")
                    {
                        Day5 = new Day(3, 5);
                        return Day5.temp;
                    }
                    else
                    {
                        return Day5.SevenDay;
                    }

                case 5:
                    if (which == "daily")
                    {
                        Day6 = new Day(2, 6);
                        return Day6.temp;
                    }
                    else
                    {
                        return Day6.SevenDay;
                    }

                case 6:
                    if (which == "daily")
                    {
                        Day7 = new Day(1, 7);
                        return Day7.temp;
                    }
                    else
                    {
                        return Day7.SevenDay;
                    }
            }
            return Day1.temp;
        }

        public void PurchaseItems(string UserInput, int TotalPurchased) {

            switch (UserInput)
            {
                case "lemons":
                    MyPlayer.MyMoney = GameStore.Cashier(1, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;

                case "sugar":
                    MyPlayer.MyMoney = GameStore.Cashier(2, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;

                case "vodka":
                    MyPlayer.MyMoney = GameStore.Cashier(3, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;

                case "ice":
                    MyPlayer.MyMoney = GameStore.Cashier(4, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;

                case "cups":
                    MyPlayer.MyMoney = GameStore.Cashier(5, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;
            }
        }
    }
}
