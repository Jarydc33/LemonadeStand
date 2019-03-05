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

        public int[] SevenForecast()
        {
            System.Random rnd = new System.Random();
            for (int i = 0; i < DaysLeft; i++)
            {
                TempPlace[i] = rnd.Next(69, 90);
            }
            return TempPlace;
        }

        public int DailyWeather()
        {
            DailyTemp = TempPlace[0];
            return DailyTemp;
           
        }

    }
}