using System;
using System.Windows.Input;
using WeatherApp.Commands;
using WeatherApp.Provider;
using WeatherApp.Models;
using System.Windows;

namespace WeatherApp.ViewModels
{
    public class AstronomyViewVM : BaseViewModel
    {
        #region private Label Variables
        private readonly string _title = "Astronomy";
        private readonly string _locationLbl = "Location:";
        private readonly string _dateLbl = "Date:";
        private readonly string _sunriseLbl = "Sun Rise:";
        private readonly string _sunsetLbl = "Sun Set:";
        private readonly string _moonriseLbl = "Moon Rise:";
        private readonly string _moonsetLbl = "Moon Set:";
        private readonly string _moonphaseLbl = "Moon Phase:";
        private readonly string _getAstronomyBtnLbl = "Get Astronomy Values";
        #endregion

        #region private Variables
        private string _location = "";
        private DateTime _date = DateTime.Today;
        private string _sunrise = "";
        private string _sunset = "";
        private string _moonrise = "";
        private string _moonset = "";
        private string _moonphase = "";
        #endregion

        #region Label Properties
        public string Title { get { return _title; } }
        public string LocationLbl { get { return _locationLbl; } }
        public string DateLbl { get { return _dateLbl; } }
        public string SunRiseLbl { get { return _sunriseLbl; } }
        public string SunSetLbl { get { return _sunsetLbl; } }
        public string MoonRiseLbl { get { return _moonriseLbl; } }
        public string MoonSetLbl { get { return _moonsetLbl; } }
        public string MoonPhaseLbl { get { return _moonphaseLbl; } }
        public string GetAstronomyBtnLbl { get { return _getAstronomyBtnLbl; } }
        #endregion

        #region Properties
        public string Location 
        { 
            get { return _location; }
            set { SetProperty<string>(ref _location, value, nameof(Location)); }
        }
        public DateTime Date
        {
            get { return _date.Date; }
            set { SetProperty<DateTime>(ref _date, value, nameof(Date)); }
        }
        public string SunRise
        {
            get { return _sunrise; }
            set { SetProperty<string>(ref _sunrise, value, nameof(SunRise)); }
        }
        public string SunSet
        {
            get { return _sunset; }
            set { SetProperty<string>(ref _sunset, value, nameof(SunSet)); }
        }
        public string MoonRise
        {
            get { return _moonrise; }
            set { SetProperty<string>(ref _moonrise, value, nameof(MoonRise)); }
        }
        public string MoonSet
        {
            get { return _moonset; }
            set { SetProperty<string>(ref _moonset, value, nameof(MoonSet)); }
        }
        public string MoonPhase
        {
            get { return _moonphase; }
            set { SetProperty<string>(ref _moonphase, value, nameof(MoonPhase)); }
        }
        #endregion

        #region Commands
        public ICommand GetAstronomyValuesCommand { get; set; }
        #endregion

        public AstronomyViewVM()
        {
            GetAstronomyValuesCommand = new Command(GetValuesFromAPI, (x) => { return true; });
        }

        private async void GetValuesFromAPI(object parameter)
        {
            AstronomyProvider astronomyProvider = new AstronomyProvider();
            AstronomyResponse astronomyResponse = await astronomyProvider.GetAstronomyAsync(Location, Date.Date.ToString("yyyy-MM-dd"));
            if (astronomyResponse == null)
            {
                MessageBox.Show("Request Processing failed! Please check the Location and Date");
                return;
            }

            SunRise = astronomyResponse.Astronomy.Astro.SunRise;
            SunSet = astronomyResponse.Astronomy.Astro.SunSet;
            MoonRise = astronomyResponse.Astronomy.Astro.MoonRise;
            MoonSet = astronomyResponse.Astronomy.Astro.MoonSet;
            MoonPhase = astronomyResponse.Astronomy.Astro.MoonPhase;
        }
    }
}
