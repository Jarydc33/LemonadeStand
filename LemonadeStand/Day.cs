using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {        
        public Weather Forecast;
        public int temp;
        public int[] SevenDay;

        public Day(int DaysLeft, int CurrentDay)
        {
            Forecast = new Weather(DaysLeft, CurrentDay);
            SevenDay = new int[DaysLeft-1];
            SevenDayForecast();
            GetDaily();
        }

        public void GetDaily()
        {
            temp = Forecast.DailyWeather();
            
        }

        public void SevenDayForecast()
        {
            SevenDay = Forecast.SevenForecast();
        }

    }
}