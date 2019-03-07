using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Game
    {
        public UserInterface UserInterface;
        public Player MyPlayer1;
        public Player MyPlayer2;
        public Store GameStore;
        public List<Day> days;
        public List<Player> players;
        public string whatNext;
        public int gameCounter;
        public bool multiPlayer;
        public int playerCounter;
        int[] recipe;

        public Game()
        {
            UserInterface = new UserInterface();
            GameStore = new Store();
            days = new List<Day>();
            gameCounter = 0;
            playerCounter = 2;
            recipe = new int[3] { 1, 1, 1 };
            MyPlayer1 = new Player();
            CreateDays();
            PlayerChooser();
        }

        public void PlayerChooser()
        {
            string playerNumber = UserInterface.NumberOfPlayers();
            switch (playerNumber)
            {
                case "friend":
                    MyPlayer2 = new Player();
                    multiPlayer = true;
                    break;

                case "none":
                    multiPlayer = false;
                    break;

                default:
                    UserInterface.DefaultResponse();
                    PlayerChooser();
                    break;
            }

            players = new List<Player>();
            players.Add(MyPlayer1);

            string[] name = UserInterface.Welcome(multiPlayer);
            MyPlayer1.myName = name[0];
            if(multiPlayer)
            {
                MyPlayer2.myName = name[1];
                players.Add(MyPlayer2);
            }
            if (multiPlayer) { UserInterface.WhoseTurn(players[playerCounter % 2].myName); }
            Console.Clear();
            GamePlay();
        }

        public void GamePlay()
        {            
            UserInterface.ViewInventory(players[playerCounter%2].MyInventory.totalInventory, players[playerCounter%2].myGrubs);
            CheckContinuingGameplay();
            whatNext = UserInterface.MainMenu(players[playerCounter%2].myName);

            switch (whatNext)
            {
                case "daily":

                    UserInterface.OutputDaily(days[gameCounter].temperature);
                    GamePlay();

                    break;

                case "weekly":

                    UserInterface.OutputWeekly(days[gameCounter].sevenDayForecast);
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

                    players[playerCounter % 2].MyRecipe.ChangeRecipe(recipe);
                    Console.Clear();
                    GamePlay();

                    break;

                case "price":

                    string potentialprice = UserInterface.ChangePrice();
                    int newPrice = AttemptParseInt(potentialprice);

                    players[playerCounter % 2].myPrice = newPrice;
                    Console.Clear();
                    GamePlay();

                    break;

                case "make":

                    if (players[playerCounter % 2].hasMade) { UserInterface.MakingYourLemonade(); GamePlay(); }

                    int invTest = players[playerCounter % 2].MyInventory.UpdateInventoryRecipe(recipe);
                    if (invTest == 1) { UserInterface.TooMuchChange(invTest); GamePlay(); }

                    players[playerCounter % 2].MakeLemonade();
                    UserInterface.MakingYourLemonade();
                    GamePlay();

                    break;

                case "start":

                    if (!players[playerCounter % 2].hasMade) { UserInterface.MakeYourNade(); GamePlay(); }
                    int CurrentTemp;
                    Console.Clear();
                    CurrentTemp = days[gameCounter].temperature;
                    days[gameCounter].CreateMonkeys();

                    foreach(Customer monkey in days[gameCounter].customers)
                    {
                        monkey.makePurchase(players[playerCounter % 2].MyRecipe.howSweet, players[playerCounter % 2].MyRecipe.howCold, players[playerCounter % 2].myPrice, CurrentTemp);
                        CupChecker(monkey.howMany);
                        players[playerCounter % 2].UpdateDaily(monkey.howMany);
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
                        
            int startingCash = players[playerCounter % 2].myGrubs;

            switch (userInput)
            {
                case "bananas":
                    players[playerCounter % 2].myGrubs = GameStore.Cashier(1, players[playerCounter % 2].myGrubs, players[playerCounter % 2].MyInventory.totalInventory, totalPurchased);
                    break;

                case "bugs":
                    players[playerCounter % 2].myGrubs = GameStore.Cashier(2, players[playerCounter % 2].myGrubs, players[playerCounter % 2].MyInventory.totalInventory, totalPurchased);
                    break;

                case "ice":
                    players[playerCounter % 2].myGrubs = GameStore.Cashier(3, players[playerCounter % 2].myGrubs, players[playerCounter % 2].MyInventory.totalInventory, totalPurchased);
                    break;

                case "cups":
                    players[playerCounter % 2].myGrubs = GameStore.Cashier(4, players[playerCounter % 2].myGrubs, players[playerCounter % 2].MyInventory.totalInventory, totalPurchased);
                    break;

                case "all":
                    players[playerCounter % 2].myGrubs = GameStore.Cashier(5, players[playerCounter % 2].myGrubs, players[playerCounter % 2].MyInventory.totalInventory, totalPurchased);
                    break;

                default:
                    UserInterface.DefaultResponse();
                    GamePlay();
                    break;
            }

            if(players[playerCounter % 2].myGrubs == startingCash)
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
            if(!multiPlayer)
            {
                gameCounter++;
            }
            else if(playerCounter % 2 == 1)
            {
                gameCounter++;
            }

            if(gameCounter > 6)
            {
                if (multiPlayer) { CompareScores(); }

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
            if(players[playerCounter % 2].myGrubs == 0)
            {
                for(int i = 0; i < players[playerCounter % 2].MyInventory.totalInventory.Length; i++)
                {
                    if(players[playerCounter % 2].MyInventory.totalInventory[i] == 0)
                    {
                        UserInterface.NoMoreStuff();
                        gameCounter = 8;
                        CounterChecker();
                    }
                }
            }
        }
        
        public void CupChecker(int HowMany)
        {
            bool HasCups = true;
            HasCups = players[playerCounter % 2].MyInventory.UpdateInventoryGame(HowMany);
            if (!HasCups) { UserInterface.NoMoreCups(); UpdateEndOfDay(); }
        }

        public void CompareScores()
        {
            int score = 0;
            if(players[0].myGrubs > players[1].myGrubs)
            {
                score = 1;
            }
            UserInterface.MultiplayerWinner(score, players[0].myGrubs, players[1].myGrubs);
        }
        
        public void UpdateEndOfDay()
        {
            players[playerCounter % 2].UpdateTotal(GameStore.cashSpent);

            if (players[playerCounter % 2].totalProfit > 0) { players[playerCounter % 2].myGrubs += players[playerCounter % 2].dailyProfit; }

            UserInterface.DailySummary(gameCounter+1, players[playerCounter % 2].dailyProfit, players[playerCounter % 2].totalProfit);
            CounterChecker();
            players[playerCounter % 2].ResetDaily();
            GameStore.CashSpentReset();
            if(multiPlayer) { playerCounter++; UserInterface.WhoseTurn(players[playerCounter % 2].myName); }
            Console.Clear();
            GamePlay();
        }
    }
}
