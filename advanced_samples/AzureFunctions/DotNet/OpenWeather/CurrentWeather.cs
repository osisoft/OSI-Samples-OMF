﻿using System;
using Newtonsoft.Json.Linq;
using OSIsoft.Omf;
using OSIsoft.Omf.DefinitionAttributes;

namespace OpenWeather
{
    [OmfType(ClassificationType = ClassificationType.Dynamic, Name = "CurrentWeather", Description = "Current weather data for a specific location")]
    public class CurrentWeather
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static readonly double KelvinOffset = -273.15;

        public CurrentWeather(JObject data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Timestamp = Epoch.AddSeconds((int)data["dt"]);
            Name = (string)data["name"];
            var coord = data["coord"];
            Longitude = (double)coord["lon"];
            Latitude = (double)coord["lat"];
            var weather = data["weather"][0];
            WeatherId = (int)weather["id"];
            WeatherMain = (string)weather["main"];
            WeatherDescription = (string)weather["description"];
            WeatherIcon = (string)weather["icon"];
            var main = data["main"];
            Humidity = (double)main["humidity"];
            Temp = Math.Round((double)main["temp"] + KelvinOffset, 3);
            TempMin = Math.Round((double)main["temp_min"] + KelvinOffset, 3);
            TempMax = Math.Round((double)main["temp_max"] + KelvinOffset, 3);
            Pressure = ((double)main["pressure"]) / 10;
            var wind = data["wind"];
            WindSpeed = (double)wind["speed"];
            WindDeg = (double)wind["deg"];
            var clouds = data["clouds"];
            CloudCover = (double)clouds["all"];
        }

        [OmfProperty(IsIndex = true)]
        public DateTime Timestamp { get; set; }
        public string Name { get; set; }
        [OmfProperty(Uom = "°")]
        public double Longitude { get; set; }
        [OmfProperty(Uom = "°")]
        public double Latitude { get; set; }
        public int WeatherId { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public string WeatherIcon { get; set; }
        [OmfProperty(Uom ="%")]
        public double Humidity { get; set; }
        [OmfProperty(Uom = "°C")]
        public double Temp { get; set; }
        [OmfProperty(Uom = "°C")]
        public double TempMin { get; set; }
        [OmfProperty(Uom = "°C")]
        public double TempMax { get; set; }
        [OmfProperty(Uom = "kPa")]
        public double Pressure { get; set; }
        [OmfProperty(Uom ="m/s")]
        public double WindSpeed { get; set; }
        [OmfProperty(Uom = "°")]
        public double WindDeg { get; set; }
        [OmfProperty(Uom = "%")]
        public double CloudCover { get; set; }
    }
}
