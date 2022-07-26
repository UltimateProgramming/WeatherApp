using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Manager;
using WeatherApp.Models;

namespace WeatherApp.Provider
{
    public class AstronomyProvider : APIProvider
    {
        private HttpClient _client = new HttpClient();

        private string JsonType { get { return "astronomy.json"; } }
        private string LocationParameter { get { return "&q="; } }
        private string DateParameter { get { return "&dt="; } }

        public AstronomyProvider() { }

        public async Task<AstronomyResponse> GetAstronomyAsync(string locationname, string datestr)
        {
            AstronomyResponse currentWeatherResponse = null;
            StringBuilder URLBuilder = new StringBuilder();
            CreateURL(URLBuilder, locationname, datestr);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await _client.GetAsync(URLBuilder.ToString());
            string responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                currentWeatherResponse = JsonConvert.DeserializeObject<AstronomyResponse>(responseString);
            }
            return currentWeatherResponse;
        }

        private void CreateURL(StringBuilder URLBuilder, string locationname, string datestr)
        {
            URLBuilder.Append(BaseURL);
            URLBuilder.Append("/" + JsonType + "?");
            URLBuilder.Append(APIKeyParameterName + SecretManager.Instance.Secret.ApiKey);
            URLBuilder.Append(LocationParameter + locationname);
            URLBuilder.Append(DateParameter + datestr);
        }
    }
}
