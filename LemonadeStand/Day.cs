using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    public class Day
    {        
        Weather Forecast;
        public List<Customer> customers;
        public int temperature;
        public int[] sevenDayForecast;
        public Random numberGenerator;

        public Day(int daysLeft, int currentDay)
        {
            Forecast = new Weather(daysLeft, currentDay);
            customers = new List<Customer>();
            sevenDayForecast = new int[daysLeft-1];
            numberGenerator = new Random();
            CreateMonkeys();
            SevenDayForecastGetter();
            GetDailyWeather();
        }

        public void GetDailyWeather()
        {
            temperature = Forecast.DailyWeather(numberGenerator);
            
        }

        public void SevenDayForecastGetter()
        {
            sevenDayForecast = Forecast.SevenForecast(numberGenerator);
        }

        public void CreateMonkeys()
        {
            customers = new List<Customer>();
            int preference;
            int price;
            int name;
            string postName;
            for (int i = 0; i < 15; i++)
            {
                preference = CustomerRandomizer(1, 4);
                price = CustomerRandomizer(5, 15);
                name = CustomerRandomizer(0, 9);
                postName = NameChooser(name);
                customers.Add(new Customer(preference, price, postName));
            }
        }

        public int CustomerRandomizer(int low, int high)
        {
            int preference = numberGenerator.Next(low, high);
            return preference;
        }

        public string NameChooser(int randomNumber)
        {
            List<string> names = new List<string>();
            names.Add("Alex, the Monkey");
            names.Add("KingKong, the APE");
            names.Add("Vivian, the Baboon");
            names.Add("BigBoy, the Proboscis");
            names.Add("Devin, the Chimp");
            names.Add("Bradford, the Gorilla");
            names.Add("Jimmy, the baby monkey");
            names.Add("Louis, the Orangutan");
            names.Add("Gill, the Tiger");
            names.Add("Aiai, the Bonobo");

            return names[randomNumber];
        }

    }
}