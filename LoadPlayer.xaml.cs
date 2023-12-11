using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
    public partial class LoadPlayer : Page
    {
        public LoadPlayer()
        {
            InitializeComponent();
        }
        private void PlayerNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmButton_Click(sender, e);
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text;
            if (!string.IsNullOrWhiteSpace(playerName))
            {
                string playerFileName = playerName + ".txt";
                try
                {
                    string[] lines = File.ReadAllLines(playerFileName);
                    Player player = new Player();

                    Confirm.Visibility = Visibility.Collapsed;
                    Player.Visibility = Visibility.Collapsed;
                    PlayerNameTextBox.Visibility = Visibility.Collapsed;

                    LoadPlayerFrame.Visibility = Visibility.Visible;
                    LoadPlayerFrame.Navigate(new Menu(player));

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();
                            switch (key)
                            {
                                case "Name":
                                    player.Name = value;
                                    break;
                                case "Health":
                                    player.Health = int.Parse(value);
                                    break;
                                case "Gold":
                                    player.Gold = int.Parse(value);
                                    break;
                                case "Attack":
                                    player.Attack = int.Parse(value);
                                    break;
                                case "Armor":
                                    player.Armor = int.Parse(value);
                                    break;
                                case "Potions":
                                    player.Potions = int.Parse(value);
                                    break;
                            }
                        }
                    }

                    MessageBox.Show("Wczytano gracza: " + playerName);

                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Taki gracz nie istnieje.");
                }
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić nazwę użytkownika.");
            }
        }


    }
}
