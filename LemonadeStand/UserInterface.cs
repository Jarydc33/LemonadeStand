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
            string WhatNext = Console.ReadLine();
            return WhatNext;
        }

        public void OutputDaily(int temp)
        {
            Console.WriteLine("The current temperature is: " + temp + ".");
        }


    }
}