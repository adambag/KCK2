using System;
using System.Collections.Generic;
using System.IO;
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

    public partial class NewPlayer : Page
    {

        public NewPlayer()
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
                if (!File.Exists(playerFileName))
                {
                    using (StreamWriter writer = File.CreateText(playerFileName))
                    {
                        writer.WriteLine("Name:" + playerName);
                        writer.WriteLine("Health:100");
                        writer.WriteLine("Gold:0");
                        writer.WriteLine("Attack:10");
                        writer.WriteLine("Armor:5");
                        writer.WriteLine("Potions:5");
                    }
                    MessageBox.Show("Nowy profil gracza został utworzony.");

                    Player player = new Player();
                    NewPlayerFrame.Navigate(new Menu(player));
                }
                else
                {
                    MessageBox.Show("Profil gracza o tej nazwie już istnieje.");
                }
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić nazwę użytkownika.");
            }
        }


    }
}
