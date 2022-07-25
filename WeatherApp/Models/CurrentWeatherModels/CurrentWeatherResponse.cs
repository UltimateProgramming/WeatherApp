using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class CurrentWeatherResponse
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}
