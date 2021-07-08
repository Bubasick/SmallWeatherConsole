using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WeatherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Weather weather = GetWeather("https://goweather.herokuapp.com/weather/Kyiv");
            Console.WriteLine(weather.Temperature);
        }
        public static Weather GetWeather(string uri)
        {
            WebRequest request = WebRequest.Create(uri);
            WebResponse response = request.GetResponse();
            Weather weatherForecast;
            using (Stream data = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(data);

                string responseFromServer = reader.ReadToEnd();

                weatherForecast = JsonConvert.DeserializeObject<Weather>(responseFromServer);


            }
            response.Close();

            return weatherForecast;

        }
    }
    public class Weather
    {
        public String Temperature { get; set; }
        public String Wind { get; set; }
        public String Description { get; set; }
        public List<Forecast> Forecast { get; set; }


    }

    public class Forecast
    {
        public int Day { get; set; }
        public String Temperature { get; set; }
        public String Wind { get; set; }
    }
}
