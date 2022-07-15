using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherApp.Commands;

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
        #endregion

        #region Commands
        ICommand MenuButtonCheckedCommand;
        #endregion

        public MainViewVM(Frame frame)
        {
            _frame = frame;
            MenuButtonCheckedCommand = new Command(CheckMenuButton, CanCheckMenuButton);
        }

        private void CheckMenuButton(object value)
        {

        }

        private bool CanCheckMenuButton(object value)
        {
            bool IsChecked;
            if (_radioButtonCheckedDict.TryGetValue()
        }

    }
}
