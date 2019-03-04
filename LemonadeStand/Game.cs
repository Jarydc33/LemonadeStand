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
            Day1 = new Day();
            Day2 = new Day();
            Day3 = new Day();
            Day4 = new Day();
            Day5 = new Day();
            Day6 = new Day();
            Day7 = new Day();
            UserInterface.Welcome();
            BeginGame();
        }

        public void BeginGame()
        {
            MyPlayer = new Player();
            MyPlayer
        }

       
    }
}