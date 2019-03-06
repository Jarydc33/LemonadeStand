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
        public List<Customer> customerList;
        public List<Day> dayList;
        public string name;
        public string whatNext;
        public int counter;
        public Day day1;
        public Day day2;
        public Day day3;
        public Day day4;
        public Day day5;
        public Day day6;
        public Day day7;
        Random gen = new Random();
        int[] recipe;

        public Game()
        {
            UserInterface = new UserInterface();
            GameStore = new Store();
            customerList = new List<Customer>();
            dayList = new List<Day>();
            counter = 0;
            recipe = new int[3] { 1, 1, 1 };
            day1 = new Day(7,1);
            day2 = new Day(6,2);
            day3 = new Day(5,3);
            day4 = new Day(4,4);
            day5 = new Day(3,5);
            day6 = new Day(2,6);
            day7 = new Day(1,7);
            name = UserInterface.Welcome();
            MyPlayer = new Player(name);
            CreateDays();
            GamePlay();
        }

        public void GamePlay()
        {            
            UserInterface.ViewInventory(MyPlayer.MyInventory.TotalInventory, MyPlayer.MyMoney);
            CheckContinuingGameplay();
            whatNext = UserInterface.MainMenu(name);

            switch (whatNext)
            {
                case "daily":
                    //int[] temp = DetermineDay("daily");

                    UserInterface.OutputDaily(dayList[counter].temp);
                    GamePlay();
                    break;

                case "weekly":
                    //int[] forecast = DetermineDay("weekly");
                    UserInterface.OutputWeekly(dayList[counter].SevenDay);
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
                    UserInterface.ViewRecipe(recipe);
                    string[] PotentialRecipe = UserInterface.ChangeRecipe();
                    recipe[0] = AttemptParseInt(PotentialRecipe[0]);
                    recipe[1] = AttemptParseInt(PotentialRecipe[1]);
                    recipe[2] = AttemptParseInt(PotentialRecipe[2]);
                    MyPlayer.MyRecipe.ChangeRecipe(recipe);
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
                    int InvTest = MyPlayer.MyInventory.UpdateInventoryRecipe(recipe);
                    if (InvTest == 1) { UserInterface.TooMuchChange(InvTest); GamePlay(); }
                    MyPlayer.MakeLemonade();
                    UserInterface.MakingYourLemonade();
                    GamePlay();
                    break;

                case "start":

                    if (!MyPlayer.HasMade) { UserInterface.MakeYourNade(); GamePlay(); }
                    int CurrentTemp;
                    
                    CurrentTemp = dayList[counter].temp;
                    CreateMonkeys();

                    foreach(Customer monkey in customerList)
                    {
                        monkey.Purchase(MyPlayer.MyRecipe.HowSweet, MyPlayer.MyRecipe.HowCold, MyPlayer.MyPrice, CurrentTemp);
                        CupChecker(monkey.HowMany);
                        MyPlayer.UpdateDaily(monkey.HowMany);
                        UserInterface.CustomerPurchase(monkey.Name, monkey.CustomerThought);
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
                dayList.Add(new Day(i, 8 - i));
            }
        }

        public void CreateMonkeys()
        {
            int preference;
            int price;
            int name;
            string postName;
            for(int i = 0; i < 15; i++)
            {
                preference = CustomerRandomizer(1,4);
                price = CustomerRandomizer(5, 15);
                name = CustomerRandomizer(0,9);
                postName = NameChooser(name);
                customerList.Add(new Customer(preference,price,postName));
            }
        }

        public int CustomerRandomizer(int low, int high)
        {
            int preference = gen.Next(low,high);
            return preference;
        }

        public string NameChooser(int randomNumber)
        {
            List<string> names = new List<string>();
            names.Add("Alex, the Monkey");
            names.Add("KingKong, the APE");
            names.Add("Vivian, the Baboon");
            names.Add("BigBoy, the Proboscis");
            names.Add("Devin, the Chimp");
            names.Add("Bradford, the Gorilla");
            names.Add("Jimmy, the baby monkey");
            names.Add("Louis, the Orangutan");
            names.Add("Gill, the Tiger");
            names.Add("Aiai, the Bonobo");

            return names[randomNumber];
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
            if(counter > 6)
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
        //Here as well, I moved this code to have it`s own method since it has the specific job of updating other methods
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
