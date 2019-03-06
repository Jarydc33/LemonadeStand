using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {        
        public Weather Forecast;
        public int temp;
        public int[] sevenDay;

        public Day(int daysLeft, int currentDay)
        {
            Forecast = new Weather(daysLeft, currentDay);
            sevenDay = new int[daysLeft-1];
            SevenDayForecast();
            GetDaily();
        }

        public void GetDaily()
        {
            temp = Forecast.DailyWeather();
            
        }

        public void SevenDayForecast()
        {
            sevenDay = Forecast.SevenForecast();
        }

    }
}