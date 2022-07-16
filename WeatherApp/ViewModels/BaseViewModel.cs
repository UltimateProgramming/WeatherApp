using System.Collections.Generic;
using System.ComponentModel;

namespace WeatherApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void SetProperty<T>(ref T value, T newValue, string propertyname)
        {
            if (EqualityComparer<T>.Default.Equals(value, newValue))
                return;
            value = newValue;
            OnPropertyChanged(propertyname);
        }

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
