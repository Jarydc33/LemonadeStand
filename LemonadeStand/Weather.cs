using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Weather
    {
        public int DaysLeft;
        public int[] TempPlace;
        public int DailyTemp;
        public int CurrentDay;

        public Weather(int daysleft, int currentday)
        {
            DaysLeft = daysleft;
            TempPlace = new int[daysleft];
            CurrentDay = currentday - 1;
        }

        public void SevenForecast()
        {
            for (int i = 0; i < DaysLeft; i++)
            {
                System.Random rnd = new System.Random();
                TempPlace[i] = rnd.Next(69, 90);
            }
        }

        public void DailyWeather()
        {
            System.Random rnd2 = new System.Random();
            DailyTemp = rnd2.Next(CurrentDay - 3, CurrentDay + 5);
           
        }

    }
}