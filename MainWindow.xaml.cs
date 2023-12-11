using System.Text;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Player player = new Player();
            Menu menuPage = new Menu(player);
            MainContentFrame.Navigate(menuPage);
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartView.Visibility = Visibility.Collapsed;
            StartButton.Visibility = Visibility.Collapsed;

            MainContentFrame.Visibility = Visibility.Visible;
            MainContentFrame.Navigate(new StartPage());
        }
    }
}