

namespace WeatherApp.ViewModels
{
    public class CurrentWeatherViewVM : BaseViewModel
    {
        private readonly string _title = "Current Weather";
        private readonly string _locationLbl = "Location:";
        private readonly string _dateLbl = "Date:";
        private readonly string _timeLbl = "Time:";
        private string _temparature = "0";

        public string Title { get { return _title; } }
        public string LocationLbl { get { return _locationLbl; } }
        public string DateLbl { get { return _dateLbl; } }
        public string TimeLbl { get { return _timeLbl; } }
        public string Temparature
        {
            get { return _temparature + "°C"; }
            set { SetProperty<string>(ref _temparature, value, nameof(Temparature)); }

        }

    }
}
