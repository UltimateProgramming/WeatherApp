using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherApp.Manager;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class MainViewVM : BaseViewModel
    {
        #region private Variables
        private readonly string _appName = "WeatherApp";
        private Frame _frame;
        private Dictionary<string, bool> _radioButtonCheckedDict = new Dictionary<string, bool>();
        #endregion

        #region Properties
        public string AppName
        {
            get { return _appName; }
        }

        public Dictionary<string, bool> RadioButtonsChecked
        {
            get { return _radioButtonCheckedDict; }
        }
        #endregion

        #region Commands
        ICommand MenuButtonCheckedCommand;
        #endregion

        public MainViewVM(Frame frame)
        {
            _frame = frame;
        }

        public void SetRadioButtonsChecked(string key, bool value)
        {
            if (!_radioButtonCheckedDict.ContainsKey(key))
                _radioButtonCheckedDict.Add(key, value);
            else
                _radioButtonCheckedDict[key] = value;
        }

        public void SetCurrentWeatherView(string viewname)
        { 
            if (!PageUserControlManager.Instance.HasSpecificUserControl(viewname))
                PageUserControlManager.Instance.AddUserControlPage(viewname, new CurrentWeatherView());

            _frame.Content = PageUserControlManager.Instance.GetSpecificUserControl(viewname);                
        }
    }
}
