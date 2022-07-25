using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using WeatherApp.Models;
using WeatherApp.Manager;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace WeatherApp.Provider
{
    public class CurrentWeatherProvider : APIProvider
    {
        private HttpClient client = new HttpClient();
        private string JsonType { get { return "current.json"; } }
        private string LocationParameter { get { return "&q="; } }
        private string AirQualtityParameter { get { return "&aqi="; } }

        public CurrentWeatherProvider() { }

        public async Task<CurrentWeatherResponse> GetCurrentWeatherAsync(string locationname, bool includeAirQuality)
        {
            CurrentWeatherResponse currentWeatherResponse = null;
            StringBuilder URLBuilder = new StringBuilder();
            CreateURL(URLBuilder, locationname, includeAirQuality);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(URLBuilder.ToString());
            string responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                currentWeatherResponse = JsonConvert.DeserializeObject<CurrentWeatherResponse>(responseString);
            }
            return currentWeatherResponse;
        }

        private void CreateURL(StringBuilder URLBuilder, string locationname, bool includeAirQuality)
        {
            URLBuilder.Append(BaseURL);
            URLBuilder.Append("/" + JsonType + "?");
            URLBuilder.Append(APIKeyParameterName + SecretManager.Setting.Secret.ApiKey);
            URLBuilder.Append(LocationParameter + locationname);
            string airquality = "";
            airquality = includeAirQuality ? "yes" : "no";
            URLBuilder.Append(AirQualtityParameter + airquality);
        }
    }
}
