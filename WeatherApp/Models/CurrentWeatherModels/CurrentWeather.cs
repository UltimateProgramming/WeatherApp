using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class CurrentWeather
    {
        [JsonProperty("temp_c")]
        public double TemparatureCelsius { get; set; }

        [JsonProperty("is_day")]
        public short IsDay { get; set; }

        [JsonProperty("condition")]
        public Condition Condition { get; set; }
    }
}
