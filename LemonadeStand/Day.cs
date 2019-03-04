using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {
        public Weather DailyWeather;
        public Weather Forecast;

        public Day()
        {
            DailyWeather = new Weather();
            Forecast = new Weather();
        }


    }
}