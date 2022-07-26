using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Astronomy
    {
        [JsonProperty("astro")]
        public Astro Astro { get; set; }
    }
}
