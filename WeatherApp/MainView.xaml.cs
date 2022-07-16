using System.Windows;
using System.Windows.Controls;
using WeatherApp.ViewModels;
using WeatherApp.Views;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewVM mainViewVM;
        public MainView()
        {
            InitializeComponent();
        }
    }
}
