using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Stylize
    {
        int topBottomCounter;

        public Stylize()
        {
            topBottomCounter = 2;
        }

        public void CreateHorizontalBorder()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if(topBottomCounter % 2 == 0)
            {
                Console.SetCursorPosition(Console.WindowLeft, Console.WindowHeight - 24);
            }
            
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
                
            }
            topBottomCounter++;
        }

        public void CreateVerticalBorder()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 7; i < Console.WindowHeight - 6; i++)
            {
                Console.SetCursorPosition(Console.WindowLeft,i);
                Console.Write("|");
                Console.SetCursorPosition(Console.WindowWidth -1, i);
                Console.Write("|");
            }

        }

        public void PlaceBanana()
        {
            Console.SetCursorPosition(102, 5);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(101,6);
            Console.Write("  | ");
            Console.SetCursorPosition(101, 7);
            Console.Write("   |  ");
            Console.SetCursorPosition(100, 8);
            Console.Write("    |  ");
            Console.SetCursorPosition(100, 9);
            Console.Write("     |  ");
            Console.SetCursorPosition(100, 10);
            Console.Write("     |   ");
            Console.SetCursorPosition(99, 11);
            Console.Write("      |  ");
            Console.SetCursorPosition(99, 12);
            Console.Write("     |  ");
            Console.SetCursorPosition(98, 13);
            Console.Write("     |  ");
            Console.SetCursorPosition(98, 14);
            Console.Write("    |  ");
            Console.SetCursorPosition(97, 15);
            Console.Write("    |  ");
            Console.SetCursorPosition(96, 16);
            Console.Write("   |  ");
            Console.SetCursorPosition(95, 17);
            Console.Write("  |  ");
            Console.SetCursorPosition(95, 18);
            Console.Write("  ");
            Console.SetCursorPosition(94, 18);
            Console.Write(" ");








        }

        public void InventoryDashboard()
        {

        }

    }
}
