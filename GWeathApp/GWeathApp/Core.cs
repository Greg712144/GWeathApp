﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GWeathApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "c0071a8baaa7e9ba105e12b88e6aadc7";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",us&appid=" + key + "&units=imperial";

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if(results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + "F";
                weather.Wind = (string)results["wind"]["speed"] + "mph";
                weather.Humidity = (string)results["main"]["humidity"] + "%";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + "UTC";
                weather.Sunset = sunset.ToString() + "UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}
