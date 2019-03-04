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
            for (int i = 0; i < DaysLeft; i++)
            {
                System.Random rnd = new System.Random();
                TempPlace[i] = rnd.Next(69, 90);
            }
            return TempPlace;
        }

        public int DailyWeather()
        {
            System.Random rnd2 = new System.Random();
            DailyTemp = rnd2.Next(TempPlace[CurrentDay], TempPlace[CurrentDay]);
            DailyTemp = rnd2.Next(DailyTemp - 3, DailyTemp + 5);
            return DailyTemp;
           
        }

    }
}