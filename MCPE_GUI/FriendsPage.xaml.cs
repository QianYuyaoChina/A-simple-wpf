using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MCPE_GUI
{
    /// <summary>
    /// FriendsPage.xaml 的交互逻辑
    /// </summary>
    public partial class FriendsPage : Page
    {
        public ObservableCollection<Friend> Friends { get; set; }
        public FriendsPage()
        {
            Friends = new ObservableCollection<Friend>();
            InitializeComponent();
            DataContext = this;
        }
        private void DeleteFriendButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("确定要删除好友吗？", "确认删除", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var button = sender as Button;
                if (button != null && button.DataContext is Friend friend)
                {
                    Friends.Remove(friend);
                    MessageBox.Show($"好友 {friend._Name} 已被删除。", "删除成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e) {
            var dialog = new FriendDialog();
            if (dialog.ShowDialog() == true)
            {
                var newFriend = new Friend(dialog.FriendName,Friend.ApiCheckIsOnline(dialog.FriendName));
                Friends.Add(newFriend);
                MessageBox.Show($"好友 {newFriend._Name} 已添加。", "添加成功", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
