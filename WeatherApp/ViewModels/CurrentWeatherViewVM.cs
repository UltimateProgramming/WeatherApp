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
        private readonly string _regionnameLbl = "Name:";
        private readonly string _regionLbl = "Region:";
        private readonly string _getCurrentWeatherBtnLbl = "Get Current Weather";
        #endregion

        private string _temparature = "0";
        private string _date = "";
        private string _time = "";
        private string _location = "";
        private string _condition = "";
        private string _regionname = "";
        private string _region = "";

        #region Label Properties
        public string Title { get { return _title; } }
        public string LocationLbl { get { return _locationLbl; } }
        public string DateLbl { get { return _dateLbl; } }
        public string TimeLbl { get { return _timeLbl; } }
        public string ConditionLbl { get { return _conditionLbl; } }
        public string RegionNameLbl { get { return _regionnameLbl; } }
        public string RegionLbl { get { return _regionLbl; } }
        public string GetCurrentWeatherBtnLbl { get { return _getCurrentWeatherBtnLbl; } }
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
        public string RegionName
        {
            get { return _regionname; }
            set { SetProperty<string>(ref _regionname, value, nameof(RegionName)); }
        }
        public string Region
        {
            get { return _region; }
            set { SetProperty<string>(ref _region, value, nameof(Region)); }
        }

        public ICommand GetCurrentWeatherCommand { get; set; }

        public CurrentWeatherViewVM()
        {
            GetCurrentWeatherCommand = new Command(GetValuesFromAPI, (x) => { return true; });
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
            RegionName = currentWeatherResponse.Location.Name;
            Region = currentWeatherResponse.Location.Region;
        }
    }
}
