using System.Windows;
using WeatherApp.Views;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            ContentFrame.Content = new CurrentWeatherView();
        }
    }
}
