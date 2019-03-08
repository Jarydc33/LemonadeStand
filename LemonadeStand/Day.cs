using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LemonadeStand
{
    public class Day
    {        
        //Weather Forecast;
        public RealWeather Weather;
        public List<Customer> customers;
        public int temperature;
        public int[] sevenDayForecast;
        public Random numberGenerator;

        public Day(int daysLeft, int currentDay)
        {
            //Forecast = new Weather(daysLeft, currentDay);
            Weather = new RealWeather();
            customers = new List<Customer>();
            sevenDayForecast = new int[daysLeft];
            numberGenerator = new Random();
            GenerateWeather(currentDay);
            CreateMonkeys();
            SevenDayForecastGetter(daysLeft,currentDay);
            GetDailyWeather(currentDay);
        }

        public void GenerateWeather(int currentDay)
        {
            //if(currentDay == 1)
            //{
                string strurltest = "https://api.darksky.net/forecast/776a8b1c0ed27586644bc263c3652fb7/43.035,-87.9225?exclude=minutely,hourly,alerts,flags";
                WebRequest requestObject = WebRequest.Create(strurltest);
                requestObject.Method = "GET";
                HttpWebResponse responseObject = null;
                responseObject = (HttpWebResponse)requestObject.GetResponse();

                string strresulttest = null;
                using (Stream stream = responseObject.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    strresulttest = sr.ReadToEnd();
                    sr.Close();
                }

                Weather = JsonConvert.DeserializeObject<RealWeather>(strresulttest);
            //}
            
        }

        public void GetDailyWeather(int currentDay)
        {
            //temperature = Forecast.DailyWeather(numberGenerator);
            temperature = (int)Weather.daily.data[currentDay-1].temperatureHigh;

        }

        public void SevenDayForecastGetter(int daysLeft, int currentDay)
        {
            //sevenDayForecast = Forecast.SevenForecast(numberGenerator);

            for (int i = 0; i < daysLeft; i++)
            {
                sevenDayForecast[i] = (int)Weather.daily.data[i].temperatureHigh;
            }

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