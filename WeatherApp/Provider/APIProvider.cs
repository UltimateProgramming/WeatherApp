

namespace WeatherApp.Provider
{
    public abstract class APIProvider
    {
        protected string BaseURL { get { return "https://api.weatherapi.com/v1"; } }
        protected string APIKeyParameterName { get { return "key="; } }
    }
}
