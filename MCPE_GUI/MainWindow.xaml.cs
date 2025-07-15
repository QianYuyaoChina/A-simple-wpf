using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MCPE_GUI
{
    public partial class MainWindow : Window
    {
        AccountPage accountPage = new AccountPage();
        GamePage gamePage = new GamePage();
        SettingsPage settingsPage = new SettingsPage();
        ChargePage chargePage = new ChargePage();
        FriendsPage friendsPage = new FriendsPage();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 默认选中账户管理
            NavMenu.SelectedIndex = 0;
        }

        private void NavMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NavMenu.SelectedItem is ListBoxItem selectedItem)
            {
                string tag = selectedItem.Tag.ToString();
                switch (tag)
                {
                    case "AccountView":
                        MainContentFrame.Content = accountPage;
                        break;
                    case "GameView":
                        MainContentFrame.Content = gamePage;
                        break;
                    case "SettingsView":
                        MainContentFrame.Content = settingsPage;
                        break;
                    case "ChargeView":
                        MainContentFrame.Content = chargePage;
                        break;
                    case "FriendsView":
                        MainContentFrame.Content = friendsPage;
                        break;
                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}