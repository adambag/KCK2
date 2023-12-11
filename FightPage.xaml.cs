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

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace KCK2
{
    public partial class FightPage : Page
    {
        private Player player;
        private Enemy enemy;
        private Random random = new Random();

        public FightPage(Player player, Enemy enemy)
        {
            InitializeComponent();
            this.player = player;
            this.enemy = new Enemy();
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            player.DealDamage(enemy);
            UpdateFightStatus("Atakujesz przeciwnika.");
            if (enemy.Health <= 0)
            {
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    NavigationService.Navigate(new Menu(player));
                }
                EndFight(true);
            }
            PerformEnemyAction();
        }

        private void DrinkPotionButton_Click(object sender, RoutedEventArgs e)
        {
            player.Heal();
            UpdateFightStatus("Wypijasz eliksir i odzyskujesz zdrowie.");

            PerformEnemyAction();
        }

        private void PerformEnemyAction()
        {
            int action = random.Next(3);
            if (action == 0)
            {
                enemy.DealDamage(player);
                UpdateFightStatus("Przeciwnik atakuje!");
            }
            else if (action == 1)
            {
                enemy.EnemyHeal();
                UpdateFightStatus("Przeciwnik leczy się.");
            }
            else
            {
                enemy.EnemyDefend();
                UpdateFightStatus("Przeciwnik broni się.");
            }
            if (player.Health <= 0)
            {
                MessageBox.Show("Zostałeś pokonany!");
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    NavigationService.Navigate(new Menu(player));
                }
                EndFight(false);
            }
        }
        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz uciec z walki?", "Ucieczka", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new Menu(player));
            }
        }
        private void EndFight(bool playerWon)
        {
            player.ResetHealth();

            if (playerWon)
            {
                player.AddGoldForWin();
                MessageBox.Show("Pokonałeś przeciwnika! Twoje zdrowie zostało zresetowane, a ty otrzymujesz 50 złota.");
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    NavigationService.Navigate(new Menu(player));
                }
            }
            else
            {
                player.AddGoldForLoss();
                MessageBox.Show("Zostałeś pokonany! Twoje zdrowie zostało zresetowane, a ty otrzymujesz 10 złota.");
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
                else
                {
                    NavigationService.Navigate(new Menu(player));
                }
            }
        }

        private void UpdateFightStatus(string message)
        {
            PlayerActionText.Text = message;
            PlayerHealthText.Text = $"Twoje zdrowie: {player.Health}";
            EnemyHealthText.Text = $"Zdrowie przeciwnika: {enemy.Health}";
        }
    }

}

