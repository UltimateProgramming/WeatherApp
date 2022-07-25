﻿using System;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public  class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("localtime")]
        public DateTime LocalTime { get; set; }
    }
}
