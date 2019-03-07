using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Stylize
    {        
        public Stylize()
        {
            
        }

        public void CreateHorizontalBorder()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.Write((char)201);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }
        }

        public void CreateVerticalBorder()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 5; i < Console.WindowHeight - 8; i++)
            {
                Console.SetCursorPosition(Console.WindowLeft,i);
                Console.Write("|");
                Console.SetCursorPosition(Console.WindowWidth -1, i);
                Console.Write("|");
            }

        }

        public void PlaceBanana()
        {
            for(int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(100, 10);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("    ");
            }
            

        }
   
    }
}
