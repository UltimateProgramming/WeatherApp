using System.Windows.Input;
using WeatherApp.Commands;
using WeatherApp.Provider;
using WeatherApp.Models;
using System.Windows;

namespace WeatherApp.ViewModels
{
    public class CurrentWeatherViewVM : BaseViewModel
    {
        #region private Label Variables
        private readonly string _title = "Current Weather";
        private readonly string _locationLbl = "Location:";
        private readonly string _dateLbl = "Date:";
        private readonly string _timeLbl = "Time:";
        private readonly string _conditionLbl = "Condition:";
        private readonly string _getValuesBtnLbl = "Get Values";
        #endregion

        private string _temparature = "0";
        private string _date = "";
        private string _time = "";
        private string _location = "";
        private string _condition = "";

        #region Label Properties
        public string Title { get { return _title; } }
        public string LocationLbl { get { return _locationLbl; } }
        public string DateLbl { get { return _dateLbl; } }
        public string TimeLbl { get { return _timeLbl; } }
        public string ConditionLbl { get { return _conditionLbl; } }
        public string GetValueBtnLbl { get { return _getValuesBtnLbl; } }
        #endregion

        public string Temparature
        {
            get { return _temparature + "°C"; }
            set { SetProperty<string>(ref _temparature, value, nameof(Temparature)); }

        }
        public string Date
        {
            get { return _date; }
            set { SetProperty<string>(ref _date, value, nameof(Date)); }
        }
        public string Time
        {
            get { return _time; }
            set { SetProperty<string>(ref _time, value, nameof(Time)); }
        }
        public string Location 
        { 
            get { return _location; } 
            set { SetProperty<string>(ref _location, value, nameof(Location)); }
        }
        public string Condition
        {
            get { return _condition; }
            set { SetProperty<string>(ref _condition, value, nameof(Condition)); }
        }

        public ICommand GetValuesCommand { get; set; }

        public CurrentWeatherViewVM()
        {
            GetValuesCommand = new Command(GetValuesFromAPI, (x) => { return true; });
        }

        private async void GetValuesFromAPI(object parameter)
        {
            CurrentWeatherProvider currentWeatherProvider = new CurrentWeatherProvider();
            CurrentWeatherResponse currentWeatherResponse = await currentWeatherProvider.GetCurrentWeatherAsync(Location, false);
            if (currentWeatherResponse == null)
            {
                MessageBox.Show("Request Processing failed! Please check the Location");
                return;
            }

            Temparature = currentWeatherResponse.CurrentWeather.TemparatureCelsius.ToString();
            Date = currentWeatherResponse.Location.LocalTime.Date.ToShortDateString();
            Time = currentWeatherResponse.Location.LocalTime.TimeOfDay.ToString();
            Condition = currentWeatherResponse.CurrentWeather.Condition.Text;
        }
    }
}
