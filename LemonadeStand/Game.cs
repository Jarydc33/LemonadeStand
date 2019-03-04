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
        public Customer Russian;
        public Customer American;
        public Customer Duck;
        public Customer Thor;
        public string Name;
        public int counter;
        public Day Day1;
        public Day Day2;
        public Day Day3;
        public Day Day4;
        public Day Day5;
        public Day Day6;
        public Day Day7;

        public Game()
        {
            UserInterface = new UserInterface();
            GameStore = new Store();
            Russian = new Customer(4, false);
            American = new Customer(1, true);
            Duck = new Customer(2, false);
            Thor = new Customer(3, true);
            counter = 0;
            //Day1 = new Day(7,1);
            //Day2 = new Day(6,2);
            //Day3 = new Day(5,3);
            //Day4 = new Day(4,4);
            //Day5 = new Day(3,5);
            //Day6 = new Day(2,6);
            //Day7 = new Day(1,7);
            Name = UserInterface.Welcome();
            MyPlayer = new Player(Name);
            GamePlay();
        }

        public void GamePlay()
        {
            string WhatNext =  UserInterface.MainMenu(Name);

            switch (WhatNext)
            {
                case "daily":
                    int temp = DetermineDay();
                    UserInterface.OutputDaily(temp);
                    GamePlay();
                    break;

                case "weekly":

                    break;

                case "inventory":

                    break;

                case "store":

                    break;

                case "start":

                    break;
            }
        }

        public int DetermineDay()
        {
            switch (counter)
            {
                case 0:
                    //need to increase counter once day two starts
                    Day1 = new Day(7, 1);
                    return Day1.temp;

                case 1:
                    Day2 = new Day(6, 2);
                    return Day2.temp;

                case 2:
                    Day3 = new Day(5, 3);
                    return Day3.temp;

                case 3:
                    Day4 = new Day(4, 4);
                    return Day4.temp;

                case 4:
                    Day5 = new Day(3, 5);
                    return Day5.temp;

                case 5:
                    Day6 = new Day(2, 6);
                    return Day6.temp;

                case 6:
                    Day7 = new Day(1, 7);
                    return Day7.temp;
            }
            return 0;
        }
       
    }
}
