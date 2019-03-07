using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    //static
    public class UserInterface
    {

        public Stylize GameDesign;
        public List<string> MainMenuResponses;

        public UserInterface()
        {
            GameDesign = new Stylize();
            MainMenuResponses = new List<string>();
            AddMainMenuResponses();
        }

        public void AddMainMenuResponses()
        {
            MainMenuResponses.Add(" To view the daily forecast, type DAILY \n");
            MainMenuResponses.Add(" To view the weekly forecast, type WEEKLY \n");
            MainMenuResponses.Add(" To visit the store, type STORE \n");
            MainMenuResponses.Add(" To change your current recipe, type RECIPE \n");
            MainMenuResponses.Add(" To change the price of the banana-nade, type PRICE \n");
            MainMenuResponses.Add(" To make the banana-nade, type MAKE \n");
            MainMenuResponses.Add(" To start the next day, type START");
        }

        public void PlaceBanana()
        {
            GameDesign.PlaceBanana();
            Console.SetCursorPosition(Console.WindowLeft, Console.WindowTop + Console.WindowHeight - 1);
        }

        public string NumberOfPlayers()
        {
            Console.WriteLine("To kick things off, do you want to play against a friend or by yourself. Type friend or none.");
            string playerNumber = Console.ReadLine();
            return playerNumber.ToLower();
        }

        public string[] Welcome(int numberPlayers)
        {            
            Console.ForegroundColor = ConsoleColor.Blue;
            string[] name;
            Console.WriteLine("Welcome to your jungle Banana-nade stand! To start things off, Player1, what is your name? \n");

            if (numberPlayers == 2)
            {
                name = new string[2];
                name[0] = Console.ReadLine();
                Console.WriteLine("And Player2, what is your name?");
                name[1] = Console.ReadLine();
            }
            else
            {
                name = new string[1];
                name[0] = Console.ReadLine();
            }
            
            Console.Clear();
            return name;
        }

        public string MainMenu(string Name)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            GameDesign.CreateHorizontalBorder();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Welcome to your jungle Banana-nade stand, " + Name + ". What would you like to do? \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            foreach(string item in MainMenuResponses)
            {
                Console.WriteLine(item);
            }

            GameDesign.CreateVerticalBorder();
            GameDesign.CreateHorizontalBorder();
            PlaceBanana();
            Console.BackgroundColor = ConsoleColor.Black;

            string whatNext = Console.ReadLine();
            Console.Clear();
            return whatNext.ToLower();
        }

        public void WhoseTurn(string userName)
        {
                Console.WriteLine(userName + " ,it is your turn! Press any key to start.");
                Console.ReadLine();            
        }

        public void OutputDaily(int temp)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The current temperature is: " + temp + ".\n");
        }

        public void OutputWeekly(int[]forecast)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("The weather forecast is: ");
            for(int i = 0; i < forecast.Length; i++)
            {
                Console.Write(forecast[i] + " ");
            }
            Console.WriteLine("\n");
        }

        public void ViewInventory(int[] totalInventory, double totalMoney)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" INVENTORY: \n " + totalInventory[0] + " Bananas \n ");
            Console.Write(totalInventory[1] + " Bag(s) of Bugs \n ");
            Console.Write(totalInventory[2] + " Bag(s) of Ice \n ");
            Console.WriteLine(totalInventory[3] + " Cup(s).\n");
            Console.WriteLine(" You currently have " + totalMoney + " grubs in your account.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DefaultResponse()
        {
            Console.WriteLine("Error. Please input again.\n");
        }

        public string StorePrices(int[] storePrices)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("The current store prices are: " + storePrices[0] + " grubs per banana, ");
            Console.Write(storePrices[1] + " grubs per bag of bug, ");
            Console.Write(storePrices[2] + " grubs per bag of ice, and ");
            Console.WriteLine(storePrices[3] + " grubs per cup. \n");
            Console.WriteLine("What would you like to purchase? Bananas, bugs, ice, cups, or all?\n");
            PlaceBanana();
            string UserInput = Console.ReadLine();
            Console.Clear();
            return UserInput.ToLower();
        }

        public string PurchaseAmount()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("How many would you like to purchase?\n");
            PlaceBanana();
            string amountPurchased = Console.ReadLine();
            Console.Clear();
            return amountPurchased;
        }

        public void ViewRecipe(int[] currentRecipe)
        {
            Console.WriteLine("The current recipe is: " + currentRecipe[0] + " banana(s), " + currentRecipe[1] + " bag(s) of bugs, " + currentRecipe[2] +" bag(s) of ice.\n");
            
        }

        public string[] ChangeRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] recipe = new string[3];
            Console.WriteLine("The recipe will consist of a combination of bananas, bugs, and ice.\n");
            Console.WriteLine("How many bananas would you like to add?");
            recipe[0] = Console.ReadLine();
            Console.WriteLine("How many bags of bugs would you like to add?");
            recipe[1] = Console.ReadLine();
            Console.WriteLine("How many bags of ice would you like to add?");
            recipe[2] = Console.ReadLine();
            Console.Clear();
            return recipe;
        }
        
        public void CustomerPurchase(string name, string opinion)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(name + opinion + "\n");
        }

        public string ChangePrice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("What would you like to set the price as? (Hint: an average price is about 8 grubs) \n");
            PlaceBanana();
            string price = Console.ReadLine();
            Console.Clear();
            return price;

        }

        public void DailySummary(int day, double dailyProfit, double totalProfit)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Well done! You have made it to the end of Day " + day + ".\n" +
                "Your daily profit is: " + dailyProfit +" grubs.\n" +
                "Your total profit/loss is: " + totalProfit +" grubs.\n");
        }

        public void NoMoreCups()
        {
            Console.WriteLine("It looks like you ran out of cups for the last full order! Please visit the store to purchase more. The day is now over.\n");
        }

        public void TooMuchChange(int whichOne)
        {
            Console.WriteLine("You used more inventory than you currently have, please visit the store to get more supplies!\n");
        }

        public void SpentTooMuch()
        {
            Console.WriteLine("You spent more grubs than you have! Go back to the store and try again.");
        }

        public void MakeYourNade()
        {
            Console.WriteLine("You have to make your banana-nade before you can sell it!\n");
        }

        public void MakingYourLemonade()
        {
            Console.WriteLine("Your banana-nade has been made!\n");
        }

        public void NoMoreStuff()
        {
            Console.WriteLine("Looks like you ran out of money AND inventory. What a bummer!");
        }

        public void EnterToContinue()
        {
            Console.WriteLine("Now that you have seen the customer`s opinions, press any key to continue");
            Console.ReadLine();
            Console.Clear();
        }
                
        public string EndGame()
        {
            Console.WriteLine("You`ve reached the end of the game! Would you like to play again? Type yes or no");
            string ending = Console.ReadLine();
            return ending.ToLower();
        }
    }
}