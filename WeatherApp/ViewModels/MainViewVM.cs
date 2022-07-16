using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherApp.Manager;
using WeatherApp.Views;
using WeatherApp.Commands;

namespace WeatherApp.ViewModels
{
    public class MainViewVM : BaseViewModel
    {
        #region private Variables
        private readonly string _appName = "WeatherApp";
        private object _currentView;
        private bool _menuButtonChecked;
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

        public bool MainMenuButtonChecked
        {
            get { return _menuButtonChecked; }
            set { SetProperty<bool>(ref _menuButtonChecked, value, nameof(MainMenuButtonChecked)); }
        }
        #endregion

        #region Commands
        public ICommand MainMenuViewCommand { get; set; }
        #endregion

        public MainViewVM() 
        {
            MainMenuViewCommand = new Command(SetMainMenuButtonView, CanSetMainMenuButtonView);
            MainMenuButtonChecked = true;
            SetCurrentWeatherView(nameof(CurrentWeatherView));
        }

        private void SetMainMenuButtonView(object parameter)
        {
            SetCurrentWeatherView(nameof(CurrentWeatherView));
        }

        private bool CanSetMainMenuButtonView(object parameter)
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
