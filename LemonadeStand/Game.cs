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
        int[] Recipe;

        public Game()
        {
            UserInterface = new UserInterface();
            GameStore = new Store();
            Russian = new Customer(4, 3, 1.5, "Igor the Russian");
            American = new Customer(1, 3, 3.5, "David the American");
            Duck = new Customer(2, 1, 5.65, "Mallory the duck");
            Thor = new Customer(3, 2, 1.35, "Thor, god of thunder");
            counter = 1;
            Recipe = new int[3] { 1, 1, 1 };
            Day1 = new Day(7,1);
            Day2 = new Day(6,2);
            Day3 = new Day(5,3);
            Day4 = new Day(4,4);
            Day5 = new Day(3,5);
            Day6 = new Day(2,6);
            Day7 = new Day(1,7);
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

                case "recipe":
                    Recipe = UserInterface.ChangeRecipe();
                    MyPlayer.MyRecipe.ChangeRecipe(Recipe);
                    GamePlay();
                    break;

                case "price":
                    double price = UserInterface.ChangePrice();
                    MyPlayer.MyPrice = price;
                    GamePlay();
                    break;

                case "make":
                    if (MyPlayer.HasMade) { UserInterface.MakingYourLemonade(); GamePlay(); }
                    int InvTest = MyPlayer.MyInventory.UpdateInventoryRecipe(Recipe);
                    if (InvTest == 1) { UserInterface.TooMuchChange(InvTest); GamePlay(); }
                    MyPlayer.MakeLemonade();
                    UserInterface.MakingYourLemonade();
                    GamePlay();
                    break;

                case "start":

                    if (!MyPlayer.HasMade) { UserInterface.MakeYourNade(); GamePlay(); }
                    int[] CurrentTemp = new int[1];
                    bool HasCups = true;
                    for (int i = 0; i < 2; i++)
                    {
                        CurrentTemp = DetermineDay("daily");

                        Russian.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                        MyPlayer.UpdateDaily(Russian.HowMany);
                        HasCups = MyPlayer.MyInventory.UpdateInventoryGame(Russian.HowMany);
                        if (!HasCups) { UserInterface.NoMoreCups(); break; }
                        UserInterface.CustomerPurchase(Russian.Name, Russian.CustomerThought);

                        American.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                        MyPlayer.UpdateDaily(American.HowMany);
                        HasCups = MyPlayer.MyInventory.UpdateInventoryGame(American.HowMany);
                        if (!HasCups) { UserInterface.NoMoreCups(); break; }
                        UserInterface.CustomerPurchase(American.Name, American.CustomerThought);

                        Duck.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                        MyPlayer.UpdateDaily(Duck.HowMany);
                        HasCups = MyPlayer.MyInventory.UpdateInventoryGame(Duck.HowMany);
                        if (!HasCups) { UserInterface.NoMoreCups(); break; }
                        UserInterface.CustomerPurchase(Duck.Name, Duck.CustomerThought);

                        Thor.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                        MyPlayer.UpdateDaily(Thor.HowMany);
                        HasCups = MyPlayer.MyInventory.UpdateInventoryGame(Thor.HowMany);
                        if (!HasCups) { UserInterface.NoMoreCups(); break; }
                        UserInterface.CustomerPurchase(Thor.Name, Thor.CustomerThought);                        
                    }
                    MyPlayer.UpdateTotal(GameStore.CashSpent);
                    UserInterface.DailySummary(counter, MyPlayer.DailyProfit, MyPlayer.TotalProfit);
                    counter++;
                    MyPlayer.ResetDaily();
                    GamePlay();
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
                case 1:
                    //need to increase counter once day two starts
                    if(which == "daily")
                    {
                        //Day1 = new Day(7, 1);
                        return Day1.temp;
                    }
                    else
                    {
                        return Day1.SevenDay;
                    }
                case 2:
                    if (which == "daily")
                    {
                        //Day2 = new Day(6, 2);
                        return Day2.temp;
                    }
                    else
                    {
                        return Day2.SevenDay;
                    }

                case 3:
                    if (which == "daily")
                    {
                        //Day3 = new Day(5, 3);
                        return Day3.temp;
                    }
                    else
                    {
                        return Day3.SevenDay;
                    }

                case 4:
                    if (which == "daily")
                    {
                        //Day4 = new Day(4, 4);
                        return Day4.temp;
                    }
                    else
                    {
                        return Day4.SevenDay;
                    }

                case 5:
                    if (which == "daily")
                    {
                       // Day5 = new Day(3, 5);
                        return Day5.temp;
                    }
                    else
                    {
                        return Day5.SevenDay;
                    }

                case 6:
                    if (which == "daily")
                    {
                        //Day6 = new Day(2, 6);
                        return Day6.temp;
                    }
                    else
                    {
                        return Day6.SevenDay;
                    }

                case 7:
                    if (which == "daily")
                    {
                        //Day7 = new Day(1, 7);
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

                case "ice":
                    MyPlayer.MyMoney = GameStore.Cashier(3, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;

                case "cups":
                    MyPlayer.MyMoney = GameStore.Cashier(4, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;

                case "all":
                    MyPlayer.MyMoney = GameStore.Cashier(5, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;
            }
        }
    }
}
