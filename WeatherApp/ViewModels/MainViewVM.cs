using System.Windows.Input;
using WeatherApp.Manager;
using WeatherApp.Views;
using WeatherApp.Commands;

namespace WeatherApp.ViewModels
{
    public class MainViewVM : BaseViewModel
    {
        #region private Label Variables
        private string _currWeatherBtnLbl = "Current Weather";
        private string _astronomyBtnLbl = "Astronomy";
        #endregion

        #region private Variables
        private readonly string _appName = "WeatherApp";
        private object _currentView;
        private bool _currentWeatherMenuButtonChecked;
        #endregion

        #region Label Properties
        public string CurrentWeatherBtnLbl { get { return _currWeatherBtnLbl; } }
        public string AstronomyBtnLbl { get { return _astronomyBtnLbl; } }
        #endregion

        #region Properties
        public string AppName
        {
            get { return _appName; }
        }

        public object CurrentView
        {
            get { return _currentView; }
            set { SetProperty<object>(ref _currentView, value, nameof(CurrentView)); }
        }

        public bool CurrentWeatherMenuButtonChecked
        {
            get { return _currentWeatherMenuButtonChecked; }
            set { SetProperty<bool>(ref _currentWeatherMenuButtonChecked, value, nameof(CurrentWeatherMenuButtonChecked)); }
        }
        #endregion

        #region Commands
        public ICommand CurrentWeatherMenuViewCommand { get; set; }
        public ICommand AstronomyMenuViewCommand { get; set; }
        #endregion

        public MainViewVM() 
        {
            CurrentWeatherMenuViewCommand = new Command(SetCurrentWeatherMenuButtonView, CanSetCurrentWeatherMenuButtonView);
            AstronomyMenuViewCommand = new Command(SetAstronomyMenuButtonView, CanSetAstronomyMenuButtonView);
            CurrentWeatherMenuButtonChecked = true;
            SetCurrentWeatherView(nameof(CurrentWeatherView));
        }

        private void SetCurrentWeatherMenuButtonView(object parameter)
        {
            SetCurrentWeatherView(nameof(CurrentWeatherView));
        }

        private bool CanSetCurrentWeatherMenuButtonView(object parameter)
        {
            return true;
        }

        private void SetAstronomyMenuButtonView(object parameter)
        {
            CurrentView = null;
        }

        private bool CanSetAstronomyMenuButtonView(object parameter)
        {
            return true;
        }

        private void SetCurrentWeatherView(string viewname)
        { 
            if (!PageUserControlManager.Instance.HasSpecificUserControl(viewname))
                PageUserControlManager.Instance.AddUserControlPage(viewname, new CurrentWeatherView());

            CurrentView = PageUserControlManager.Instance.GetSpecificUserControl(viewname);                
        }
    }
}
