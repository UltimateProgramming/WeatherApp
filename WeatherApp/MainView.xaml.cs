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
            mainViewVM = new MainViewVM(ContentFrame);
            DataContext = mainViewVM;
            Main_RadioButton.IsChecked = true;
        }

        public void MainRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            mainViewVM.SetRadioButtonsChecked(radioButton.Name, radioButton.IsChecked.Value);
            if (mainViewVM.RadioButtonsChecked[radioButton.Name])
                mainViewVM.SetCurrentWeatherView(nameof(CurrentWeatherView));
            else
                ContentFrame.Content = null;
        }
    }
}
