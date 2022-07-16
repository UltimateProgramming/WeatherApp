

namespace WeatherApp.ViewModels
{
    public class CurrentWeatherViewVM : BaseViewModel
    {
        private readonly string _title = "Current Weather";
        private readonly string _locationLabel = "Location";

        public string Title { get { return _title; } }
        public string LocationLabel { get { return _locationLabel; } }

    }
}
