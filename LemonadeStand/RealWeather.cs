

namespace LemonadeStand
{
    public class RealWeather
    {
        public float longitude { get; set; }
        public Currently currently { get; set; }
        public Daily daily { get; set; }



        public class Currently
        {

            public float apparentTemperature { get; set; }//daily temp


        }

        public class Daily
        {
            public Datum[] data { get; set; }
        }

        public class Datum
        {

            public float temperatureHigh { get; set; }
            public float temperatureLow { get; set; }

        }

    }
}
