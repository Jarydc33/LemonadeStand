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
            return name;
        }

        public string MainMenu(string Name)
        {
            Console.WriteLine("Welcome to the Main Menu " + Name + ", what would you like to do? \n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("To view the daily forecast, type daily \n");
            Console.WriteLine("To view the weekly forecast, type weekly \n");
            Console.WriteLine("To view your current inventory, type inventory \n");
            Console.WriteLine("To visit the store, type store \n");
            Console.WriteLine("To start the next day, type start \n");
            Console.WriteLine("To change your current recipe, type recipe \n");
            string WhatNext = Console.ReadLine();
            return WhatNext;
        }

        public void OutputDaily(int temp)
        {
            Console.WriteLine("The current temperature is: " + temp + ".");
        }

        public void OutputWeekly(int[]forecast)
        {
            Console.WriteLine("The weather forecast is: ");
            for(int i = 0; i < forecast.Length; i++)
            {
                Console.WriteLine(forecast[i]);
            }

        }

        public void ViewInventory(int[] TotalInventory, double TotalMoney)
        {
            Console.Write("Your current inventory is: " + TotalInventory[0] + " lemons, ");
            Console.Write(TotalInventory[1] + " pounds of sugar, ");
            Console.Write(TotalInventory[2] + " bottles of vodka ");
            Console.Write(TotalInventory[3] + " bags of ice, and ");
            Console.WriteLine(TotalInventory[4] + " cups.");
            Console.WriteLine("You currently have $" + TotalMoney + " in your account.");
        }

        public void DefaultResponse()
        {
            Console.WriteLine("Error. Please input again.");
        }

        public string StorePrices(double[] StorePrices)
        {
            Console.Write("The current store prices are: $" + StorePrices[0] + " per lemon, $");
            Console.Write(StorePrices[1] + " per pound of sugar, $");
            Console.Write(StorePrices[2] + " per bottle of vodka, $");
            Console.Write(StorePrices[3] + " per bag of ice, and $");
            Console.WriteLine(StorePrices[4] + " per cup. \n");
            Console.WriteLine("What would you like to purchase? Lemons, sugar, vodka, ice, or cups?");
            string UserInput = Console.ReadLine();
            return UserInput;
        }

        public int PurchaseAmount()
        {
            Console.WriteLine("How many would you like to purchase?");
            int AmountPurchased = int.Parse(Console.ReadLine());
            return AmountPurchased;
        }

        public int[] ChangeRecipe()
        {
            int[] Recipe = new int[3];
            Console.WriteLine("The recipe will consist of a combination of lemons, sugar, and ice. The more lemons, the more sour it will be." +
                "The more sugar, the sweeter and so on.");
            Console.WriteLine("How many lemons would you like to add?");
            Recipe[0] = int.Parse(Console.ReadLine());
            Console.WriteLine("How many pounds of sugar would you like to add?");
            Recipe[1] = int.Parse(Console.ReadLine());
            Console.WriteLine("How many bags of ice would you like to add?");
            Recipe[2] = int.Parse(Console.ReadLine());
            return Recipe;
        }
                
    }
}