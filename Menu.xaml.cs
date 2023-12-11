using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
    

    public partial class Menu : Page
    {
        public Player player;

        public Menu(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            PlayButton.Visibility = Visibility.Collapsed;
            StatsButton.Visibility = Visibility.Collapsed;
            StoreButton.Visibility = Visibility.Collapsed;
            ExitButton.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;

            Enemy enemy = new Enemy();
            FightPage fightPage = new FightPage(player, enemy);
            MainFrame.Navigate(fightPage);
        }
        private void StatsButton_Click(object sender, RoutedEventArgs e)
        {
            if (player != null)
            {
                string playerStats = player.GetStats();
                MessageBox.Show(playerStats, "Statystyki Gracza");
            }
            else
            {
                MessageBox.Show("Obiekt player nie jest zainicjalizowany.");
            }
        }

        private void StoreButton_Click(object sender, RoutedEventArgs e)
        {
            PlayButton.Visibility = Visibility.Collapsed;
            StatsButton.Visibility = Visibility.Collapsed;
            StoreButton.Visibility = Visibility.Collapsed;
            ExitButton.Visibility = Visibility.Collapsed;

            MainFrame.Visibility = Visibility.Visible;

            Store store = new Store(player);
            StorePage storePage = new StorePage(store);
            MainFrame.Navigate(storePage);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć aplikację?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

    }
}

