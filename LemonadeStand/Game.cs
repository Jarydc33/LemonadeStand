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
        public Customer Proboscis;
        public Customer Mandrill;
        public Customer Macaque;
        public Customer Howler;
        public Customer Baboon;
        public Customer Orangutan;
        public Customer Bonobo;
        public Customer Gibbon;
        public Customer Gorilla;
        public Customer Chimpanzee;
        public string Name;
        public string WhatNext;
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
            Proboscis = new Customer(4, 10, "The Proboscis monkey");
            Mandrill = new Customer(1, 13, "The Mandrill");
            Macaque = new Customer(2, 7, "The Macaque");
            Howler = new Customer(3, 15, "The Howler monkey");
            Baboon = new Customer(3, 9, "The Baboon");
            Orangutan = new Customer(2, 9, "The Orangutan");
            Bonobo = new Customer(1, 11, "The Bonobo");
            Gibbon = new Customer(2, 10, "The Gibbon");
            Gorilla = new Customer(4, 13, "The Gorilla");
            Chimpanzee = new Customer(1, 12, "The Chimp");
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
            UserInterface.ViewInventory(MyPlayer.MyInventory.TotalInventory, MyPlayer.MyMoney);
            CheckContinuingGameplay();
            WhatNext = UserInterface.MainMenu(Name);

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
                                    
                case "store":
                    string UserInput = UserInterface.StorePrices(GameStore.StorePrices);
                    string AmountPurchased = UserInterface.PurchaseAmount();
                    int PurchaseParsed = AttemptParseInt(AmountPurchased);
                    PurchaseItems(UserInput.ToLower(), PurchaseParsed);
                    GamePlay();
                    break;

                case "recipe":
                    UserInterface.ViewRecipe(Recipe);
                    string[] PotentialRecipe = UserInterface.ChangeRecipe();
                    Recipe[0] = AttemptParseInt(PotentialRecipe[0]);
                    Recipe[1] = AttemptParseInt(PotentialRecipe[1]);
                    Recipe[2] = AttemptParseInt(PotentialRecipe[2]);
                    MyPlayer.MyRecipe.ChangeRecipe(Recipe);
                    Console.Clear();
                    GamePlay();
                    break;

                case "price":
                    string potentialprice = UserInterface.ChangePrice();
                    double NewPrice = AttemptParseDouble(potentialprice);
                    MyPlayer.MyPrice = NewPrice;
                    Console.Clear();
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
                    
                    CurrentTemp = DetermineDay("daily");
                        
                    Proboscis.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Proboscis.HowMany);
                    MyPlayer.UpdateDaily(Proboscis.HowMany);
                    UserInterface.CustomerPurchase(Proboscis.Name, Proboscis.CustomerThought);

                    Mandrill.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Mandrill.HowMany);
                    MyPlayer.UpdateDaily(Mandrill.HowMany);
                    UserInterface.CustomerPurchase(Mandrill.Name, Mandrill.CustomerThought);

                    Macaque.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Macaque.HowMany);
                    MyPlayer.UpdateDaily(Macaque.HowMany);
                    UserInterface.CustomerPurchase(Macaque.Name, Macaque.CustomerThought);

                    Howler.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Howler.HowMany);
                    MyPlayer.UpdateDaily(Howler.HowMany);
                    UserInterface.CustomerPurchase(Howler.Name, Howler.CustomerThought);

                    Baboon.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Baboon.HowMany);
                    MyPlayer.UpdateDaily(Baboon.HowMany);
                    UserInterface.CustomerPurchase(Baboon.Name, Baboon.CustomerThought);

                    Orangutan.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Orangutan.HowMany);
                    MyPlayer.UpdateDaily(Orangutan.HowMany);
                    UserInterface.CustomerPurchase(Orangutan.Name, Orangutan.CustomerThought);

                    Bonobo.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Bonobo.HowMany);
                    MyPlayer.UpdateDaily(Bonobo.HowMany);
                    UserInterface.CustomerPurchase(Bonobo.Name, Bonobo.CustomerThought);

                    Gibbon.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Gibbon.HowMany);
                    MyPlayer.UpdateDaily(Gibbon.HowMany);
                    UserInterface.CustomerPurchase(Gibbon.Name, Gibbon.CustomerThought);

                    Gorilla.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Gorilla.HowMany);
                    MyPlayer.UpdateDaily(Gorilla.HowMany);
                    UserInterface.CustomerPurchase(Gorilla.Name, Gorilla.CustomerThought);

                    Chimpanzee.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                    CupChecker(Chimpanzee.HowMany);
                    MyPlayer.UpdateDaily(Chimpanzee.HowMany);
                    UserInterface.CustomerPurchase(Chimpanzee.Name, Chimpanzee.CustomerThought);

                    UpdateEndOfDay();
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
                        
            double StartingCash = MyPlayer.MyMoney;

            switch (UserInput)
            {
                case "bananas":
                    MyPlayer.MyMoney = GameStore.Cashier(1, MyPlayer.MyMoney, MyPlayer.MyInventory.TotalInventory, TotalPurchased);
                    break;

                case "bugs":
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

                default:
                    UserInterface.DefaultResponse();
                    GamePlay();
                    break;
            }

            if(MyPlayer.MyMoney == StartingCash)
            {
                UserInterface.SpentTooMuch();                
                GamePlay();
            }
            else
            {
                GamePlay();
            }
        }

        public void CounterChecker()
        {
            counter++;
            if(counter > 7)
            {
                string BeginAgain = UserInterface.EndGame();
                if(BeginAgain == "yes")
                {
                    Console.Clear();
                    Game NewGame = new Game();
                }
                else if(BeginAgain == "no")
                {
                    Environment.Exit(0);
                }
                else
                {
                    UserInterface.DefaultResponse();
                    CounterChecker();
                }
            }
        }

        public int AttemptParseInt(string UserInput)
        {
            int SuccessfulParse;
            bool attempt = Int32.TryParse(UserInput, out SuccessfulParse);
            if (attempt)
            {
                return SuccessfulParse;
            }
            else
            {
                UserInterface.DefaultResponse();
                GamePlay();
                return 0;
            }
        }

        public double AttemptParseDouble(string UserInput)
        {
            double SuccessfulParse;
            bool attempt = Double.TryParse(UserInput, out SuccessfulParse);
            if (attempt)
            {
                return SuccessfulParse;
            }
            else
            {
                UserInterface.DefaultResponse();
                GamePlay();
                return 0;
            }
        }

        public void CheckContinuingGameplay()
        {
            if(MyPlayer.MyMoney == 0)
            {
                for(int i = 0; i < MyPlayer.MyInventory.TotalInventory.Length; i++)
                {
                    if(MyPlayer.MyInventory.TotalInventory[i] == 0)
                    {
                        UserInterface.NoMoreStuff();
                        counter = 8;
                        CounterChecker();
                    }
                }
            }
        }
        //Specifically moved this from the Start case to it`s own method in an attempt to keep to the S of SOLID.
        public void CupChecker(int HowMany)
        {
            bool HasCups = true;

            HasCups = MyPlayer.MyInventory.UpdateInventoryGame(HowMany);
            if (!HasCups) { UserInterface.NoMoreCups(); UpdateEndOfDay(); }
        }
        //Here as well I moved this code to have it`s own method since it has the specific job of updating other methods
        public void UpdateEndOfDay()
        {
            MyPlayer.UpdateTotal(GameStore.CashSpent);
            if (MyPlayer.TotalProfit > 0) { MyPlayer.MyMoney += MyPlayer.DailyProfit; }
            UserInterface.DailySummary(counter, MyPlayer.DailyProfit, MyPlayer.TotalProfit);
            CounterChecker();
            MyPlayer.ResetDaily();
            GameStore.CashSpentReset();
            GamePlay();
        }
    }
}
