

namespace LemonadeStand
{
    public class RealWeather
    {
        public Daily daily { get; set; }

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
