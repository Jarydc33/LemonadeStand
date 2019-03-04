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
            Console.WriteLine("Welcome to Lemonade Stand! To start things off, what is your name?");
            string name = Console.ReadLine();
            return name;
        }

        public void MainMenu()
        {
            
        }


    }
}