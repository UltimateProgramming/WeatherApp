using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Condition
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
