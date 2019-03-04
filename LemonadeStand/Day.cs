using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {        
        public Weather Forecast;
        public int temp;
        public int SevenDay;

        public Day(int DaysLeft, int CurrentDay)
        {
            Forecast = new Weather(DaysLeft, CurrentDay);
            GetDaily();
        }

        public void GetDaily()
        {
            Forecast.SevenForecast();
            temp = Forecast.DailyWeather();
            
        }

    }
}