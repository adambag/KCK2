using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KCK2
{
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGameButton.Visibility = Visibility.Collapsed;
            LoadGameButton.Visibility = Visibility.Collapsed;
            ExitGameButton.Visibility = Visibility.Collapsed;

            StartPageFrame.Visibility = Visibility.Visible;
            StartPageFrame.Navigate(new NewPlayer());
        }
        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGameButton.Visibility = Visibility.Collapsed;
            LoadGameButton.Visibility = Visibility.Collapsed;
            ExitGameButton.Visibility = Visibility.Collapsed;

            StartPageFrame.Visibility = Visibility.Visible;
            StartPageFrame.Navigate(new LoadPlayer());
        }
        private void ExitGameButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć aplikację?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
    
}
