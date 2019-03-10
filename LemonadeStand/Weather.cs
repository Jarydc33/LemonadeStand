using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Weather
    {
        //This class was used when I was generating my own weather. I was able to incorporate the weather API so this class is no longer used. It has been left in so
        //the instructors can see how I initially did the weather.
        public int daysLeft;
        public int[] temperatureHolder;
        public int dailyTemp;
        public int currentDay;

        public Weather(int daysleft, int currentday)
        {
            daysLeft = daysleft;
            temperatureHolder = new int[daysleft];
            currentDay = currentday - 1;
        }

        public int[] SevenForecast(Random newRandom)
        {            
            for (int i = 0; i < daysLeft; i++)
            {
                temperatureHolder[i] = newRandom.Next(75, 105);
            }
            return temperatureHolder;
        }

        public int DailyWeather(Random newRandom)
        {
            dailyTemp = temperatureHolder[0];
            dailyTemp = newRandom.Next(dailyTemp - 2, dailyTemp +2);
            return dailyTemp;
           
        }

    }
}