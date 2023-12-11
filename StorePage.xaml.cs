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
    public partial class StorePage : Page
    {
        private Store store;

        public StorePage(Store store)
        {
            InitializeComponent();
            this.store = store;
            UpdatePlayerStats();
        }

        private void UpgradeButton_Click(object sender, RoutedEventArgs e)
        {
            store.BuyWeapon();
            UpdatePlayerStats();
        }

        private void ArmorButton_Click(object sender, RoutedEventArgs e)
        {
            store.BuyArmor();
            UpdatePlayerStats();
        }

        private void PotionButton_Click(object sender, RoutedEventArgs e)
        {
            store.BuyHealingPotion();
            UpdatePlayerStats();
        }

        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(new Menu(store.Player));
            }
        }

        private void UpdatePlayerStats()
        {
            Player player = store.Player;
            PlayerGoldText.Text = $"Złoto: {player.Gold}";
        }
    }
}

