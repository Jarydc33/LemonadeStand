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
        Random rnd;

        public Weather(int daysleft, int currentday)
        {
            DaysLeft = daysleft;
            TempPlace = new int[daysleft];
            CurrentDay = currentday - 1;
            rnd = new Random();
        }

        public int[] SevenForecast()
        {            
            for (int i = 0; i < DaysLeft; i++)
            {
                TempPlace[i] = rnd.Next(75, 105);
            }
            return TempPlace;
        }

        public int DailyWeather()
        {
            DailyTemp = TempPlace[0];
            DailyTemp = rnd.Next(DailyTemp - 2, DailyTemp +2);
            return DailyTemp;
           
        }

    }
}