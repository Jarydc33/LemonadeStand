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
        public List<Day> days;
        public string name;
        public string whatNext;
        public int counter;
        int[] recipe;

        public Game()
        {
            UserInterface = new UserInterface();
            GameStore = new Store();
            days = new List<Day>();
            counter = 0;
            recipe = new int[3] { 1, 1, 1 };            
            name = UserInterface.Welcome();
            MyPlayer = new Player(name);
            CreateDays();
            GamePlay();
        }

        public void GamePlay()
        {            
            UserInterface.ViewInventory(MyPlayer.MyInventory.totalInventory, MyPlayer.myMoney);
            CheckContinuingGameplay();
            whatNext = UserInterface.MainMenu(name);

            switch (whatNext)
            {
                case "daily":

                    UserInterface.OutputDaily(days[counter].temperature);
                    GamePlay();

                    break;

                case "weekly":

                    UserInterface.OutputWeekly(days[counter].sevenDayForecast);
                    GamePlay();

                    break;
                                    
                case "store":

                    string UserInput = UserInterface.StorePrices(GameStore.storePrices);
                    string AmountPurchased = UserInterface.PurchaseAmount();
                    int PurchaseParsed = AttemptParseInt(AmountPurchased);

                    PurchaseItems(UserInput.ToLower(), PurchaseParsed);
                    GamePlay();

                    break;

                case "recipe":

                    UserInterface.ViewRecipe(recipe);
                    string[] potentialRecipe = UserInterface.ChangeRecipe();

                    recipe[0] = AttemptParseInt(potentialRecipe[0]);
                    recipe[1] = AttemptParseInt(potentialRecipe[1]);
                    recipe[2] = AttemptParseInt(potentialRecipe[2]);

                    MyPlayer.MyRecipe.ChangeRecipe(recipe);
                    Console.Clear();
                    GamePlay();

                    break;

                case "price":

                    string potentialprice = UserInterface.ChangePrice();
                    int newPrice = AttemptParseInt(potentialprice);

                    MyPlayer.myPrice = newPrice;
                    Console.Clear();
                    GamePlay();

                    break;

                case "make":

                    if (MyPlayer.hasMade) { UserInterface.MakingYourLemonade(); GamePlay(); }

                    int invTest = MyPlayer.MyInventory.UpdateInventoryRecipe(recipe);
                    if (invTest == 1) { UserInterface.TooMuchChange(invTest); GamePlay(); }

                    MyPlayer.MakeLemonade();
                    UserInterface.MakingYourLemonade();
                    GamePlay();

                    break;

                case "start":

                    if (!MyPlayer.hasMade) { UserInterface.MakeYourNade(); GamePlay(); }
                    int CurrentTemp;
                    
                    CurrentTemp = days[counter].temperature;
                    days[counter].CreateMonkeys();

                    foreach(Customer monkey in days[counter].customers)
                    {
                        monkey.makePurchase(MyPlayer.MyRecipe.howSweet, MyPlayer.MyRecipe.howCold, MyPlayer.myPrice, CurrentTemp);
                        CupChecker(monkey.howMany);
                        MyPlayer.UpdateDaily(monkey.howMany);
                        UserInterface.CustomerPurchase(monkey.name, monkey.customerThought);
                    }
                   
                    UpdateEndOfDay();

                    break;

                default:

                    UserInterface.DefaultResponse();
                    GamePlay();

                    break;
            }
        }
               
        public void CreateDays()
        {
            for(int i = 7; i > 0; i--)
            {
                days.Add(new Day(i, 8 - i));
            }
        }
               
        public void PurchaseItems(string userInput, int totalPurchased) {
                        
            int startingCash = MyPlayer.myMoney;

            switch (userInput)
            {
                case "bananas":
                    MyPlayer.myMoney = GameStore.Cashier(1, MyPlayer.myMoney, MyPlayer.MyInventory.totalInventory, totalPurchased);
                    break;

                case "bugs":
                    MyPlayer.myMoney = GameStore.Cashier(2, MyPlayer.myMoney, MyPlayer.MyInventory.totalInventory, totalPurchased);
                    break;

                case "ice":
                    MyPlayer.myMoney = GameStore.Cashier(3, MyPlayer.myMoney, MyPlayer.MyInventory.totalInventory, totalPurchased);
                    break;

                case "cups":
                    MyPlayer.myMoney = GameStore.Cashier(4, MyPlayer.myMoney, MyPlayer.MyInventory.totalInventory, totalPurchased);
                    break;

                case "all":
                    MyPlayer.myMoney = GameStore.Cashier(5, MyPlayer.myMoney, MyPlayer.MyInventory.totalInventory, totalPurchased);
                    break;

                default:
                    UserInterface.DefaultResponse();
                    GamePlay();
                    break;
            }

            if(MyPlayer.myMoney == startingCash)
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
            if(counter > 6)
            {
                string beginAgain = UserInterface.EndGame();
                if(beginAgain == "yes")
                {
                    Console.Clear();
                    Game NewGame = new Game();
                }
                else if(beginAgain == "no")
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

        public void CheckContinuingGameplay()
        {
            if(MyPlayer.myMoney == 0)
            {
                for(int i = 0; i < MyPlayer.MyInventory.totalInventory.Length; i++)
                {
                    if(MyPlayer.MyInventory.totalInventory[i] == 0)
                    {
                        UserInterface.NoMoreStuff();
                        counter = 8;
                        CounterChecker();
                    }
                }
            }
        }
        
        public void CupChecker(int HowMany)
        {
            bool HasCups = true;
            HasCups = MyPlayer.MyInventory.UpdateInventoryGame(HowMany);
            if (!HasCups) { UserInterface.NoMoreCups(); UpdateEndOfDay(); }
        }
        
        public void UpdateEndOfDay()
        {
            MyPlayer.UpdateTotal(GameStore.cashSpent);

            if (MyPlayer.totalProfit > 0) { MyPlayer.myMoney += MyPlayer.dailyProfit; }

            UserInterface.DailySummary(counter+1, MyPlayer.dailyProfit, MyPlayer.totalProfit);
            CounterChecker();
            MyPlayer.ResetDaily();
            GameStore.CashSpentReset();
            GamePlay();
        }
    }
}
