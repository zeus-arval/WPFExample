using System.Windows;

namespace BankApp.MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; private set; }

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainViewModel = CreateMainViewModel(serviceProvider);
            DataContext = MainViewModel;
        }

        private static MainViewModel CreateMainViewModel(IServiceProvider serviceProvider)
        {
            return new MainViewModel(serviceProvider);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = MainViewModel.LoadUsers();
        }
    }
}