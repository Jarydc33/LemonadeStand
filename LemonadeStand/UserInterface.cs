using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class UserInterface
    {  
        public UserInterface()
        {
            
        }

        public string Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Lemonade Stand! To start things off, what is your name? \n");
            string name = Console.ReadLine();
            Console.Clear();
            return name;
        }

        public string MainMenu(string Name)
        {            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to the Main Menu " + Name + ", what would you like to do? \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("To view the daily forecast, type DAILY \n");
            Console.WriteLine("To view the weekly forecast, type WEEKLY \n");
            Console.WriteLine("To visit the store, type STORE \n");
            Console.WriteLine("To change your current recipe, type RECIPE \n");
            Console.WriteLine("To change the price of the lemonade, type PRICE \n");
            Console.WriteLine("To make the lemonade, type MAKE \n");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("To start the next day, type START \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string WhatNext = Console.ReadLine();
            Console.Clear();
            return WhatNext;
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

        public void ViewInventory(int[] TotalInventory, double TotalMoney)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Your current inventory is: " + TotalInventory[0] + " lemons, ");
            Console.Write(TotalInventory[1] + " bag(s) of sugar, ");
            Console.Write(TotalInventory[2] + " bag(s) of ice, and ");
            Console.WriteLine(TotalInventory[3] + " cup(s).\n");
            Console.WriteLine("You currently have $" + TotalMoney + " in your account.\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
        }

        public void DefaultResponse()
        {
            Console.WriteLine("Error. Please input again.\n");
        }

        public string StorePrices(double[] StorePrices)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("The current store prices are: $" + StorePrices[0] + " per lemon, $");
            Console.Write(StorePrices[1] + " per bag of sugar, $");
            Console.Write(StorePrices[2] + " per bag of ice, and $");
            Console.WriteLine(StorePrices[3] + " per cup. \n");
            Console.WriteLine("What would you like to purchase? Lemons, sugar, ice, cups, or all?\n");
            string UserInput = Console.ReadLine();
            return UserInput.ToLower();
        }

        public string PurchaseAmount()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("How many would you like to purchase?\n");
            string AmountPurchased = Console.ReadLine();
            Console.Clear();
            return AmountPurchased;
        }

        public void ViewRecipe(int[] CurrentRecipe)
        {
            Console.WriteLine("The current recipe is: " + CurrentRecipe[0] + " lemon(s), " + CurrentRecipe[1] + " bag(s) of sugar, " + CurrentRecipe[2] +" bag(s) of ice.\n");
        }

        public string[] ChangeRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] Recipe = new string[3];
            Console.WriteLine("The recipe will consist of a combination of lemons, sugar, and ice. The more lemons, the more sour it will be." +
                "The more sugar, the sweeter and so on.\n");
            Console.WriteLine("How many lemons would you like to add?");
            Recipe[0] = Console.ReadLine();
            Console.WriteLine("How many pounds of sugar would you like to add?");
            Recipe[1] = Console.ReadLine();
            Console.WriteLine("How many bags of ice would you like to add?");
            Recipe[2] = Console.ReadLine();
            return Recipe;
        }
        
        public void CustomerPurchase(string name, string opinion)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(name + opinion + "\n");
        }

        public string ChangePrice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("What would you like to set the price as? (Hint, an average price is about $2.00) \n");
            string price = Console.ReadLine();
            return price;

        }

        public void DailySummary(int Day, double DailyProfit, double TotalProfit)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Well done! You have made it to the end of Day " + Day + ".\n " +
                "Your daily profit is: $" + DailyProfit +".\n" +
                "Your total profit/loss is: $" + TotalProfit +".\n");
        }

        public void NoMoreCups()
        {
            Console.WriteLine("It looks like you ran out of cups! Please visit the store to purchase more. The day is now over.\n");
        }

        public void TooMuchChange(int WhichOne)
        {
            Console.WriteLine("You used more inventory than you currently have, please visit the store to get more supplies!\n");
        }

        public void SpentTooMuch()
        {
            Console.WriteLine("You spent more money than you have! Go back to the store and try again.");
        }

        public void MakeYourNade()
        {
            Console.WriteLine("You have to make your lemonade before you can sell it!\n");
        }

        public void MakingYourLemonade()
        {
            Console.WriteLine("Your lemonade has been made!\n");
        }
                
        public string EndGame()
        {
            Console.WriteLine("It appears that you made it to the end of the day! Would you like to play again? Type yes or no");
            string Ending = Console.ReadLine();
            return Ending;
        }
    }
}