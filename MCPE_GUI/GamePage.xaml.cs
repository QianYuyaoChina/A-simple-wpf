using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace MCPE_GUI
{
    public partial class GamePage : Page
    {
        public static ObservableCollection<Game> Games { get; set; }
        public static Game? _selectedGame;
        public static Game? _currentGame;
        public GamePage()
        {
            InitializeComponent();
            Games = new ObservableCollection<Game>();
            DataContext = this;
        }

        private void GamesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedGame = GamesGrid.SelectedItem as Game;
            EditGameBtn.IsEnabled = _selectedGame != null;
            DeleteGameBtn.IsEnabled = _selectedGame != null;
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new GamesDialog();
            if (dialog.ShowDialog() == true)
            {
                var newGame = new Game(dialog.Username);
                Games.Add(newGame);
            }
        }

        private void EditGame_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedGame == null) return;

            var dialog = new GamesDialog(_selectedGame.Gamename);
            if (dialog.ShowDialog() == true)
            {
                _selectedGame.Id = dialog.Username;
                _selectedGame.IsCurrentGame = false; // 重置当前账户状态

            }
        }

        private void DeleteGame_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedGame == null) return;

            if (MessageBox.Show($"确定要删除服务器 '{_selectedGame.Gamename}' 吗?",
                "确认删除", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                // 如果删除的是当前账户，清除当前账户状态
                if (_selectedGame == _currentGame)
                {
                    _currentGame = null;
                }

                Games.Remove(_selectedGame);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag is Game Game)
            {
                bool success = Game.JoinGame();
                if (success)
                {
                    MessageBox.Show($"成功登录服务器 '{Game.Gamename}'。", "登录成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"登录服务器 '{Game.Gamename}' 失败，请检查您的网络连接或服务器状态。",
                        "登录失败", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void DirectlyConn_Click(object sender, RoutedEventArgs e)
        {
            var  dialog = new Directly_Connect();
            if (dialog.ShowDialog() == true)
            {

            }
        }
    }
}