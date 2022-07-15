using System.Windows;
using System.Windows.Controls;
using WeatherApp.ViewModels;

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
        }

        public void MainRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

        }
    }
}
