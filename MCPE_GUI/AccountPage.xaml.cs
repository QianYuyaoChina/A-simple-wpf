using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Linq;

namespace MCPE_GUI
{
    public partial class AccountPage : Page
    {
        public static ObservableCollection<Account> Accounts { get; set; }
        public static Account? _selectedAccount;
        public static Account? _currentAccount;

        public AccountPage()
        {
            Accounts = new ObservableCollection<Account>();
            InitializeComponent();
            DataContext = this;

            // 添加示例账户
            Accounts.Add(new Account("admin", "123456"));
            Accounts.Add(new Account("user1", "password1"));
            Accounts.Add(new Account("test", "test123"));
            Accounts.Add(new Account("player", "minecraft"));
            Accounts.Add(new Account("developer", "code123"));

            // 初始化当前账户显示
            txtCurrentAccount.Text = "无";
        }

        private void SetCurrentAccount(Account account)
        {
            // 清除之前的当前账户状态
            foreach (var acc in Accounts)
            {
                acc.IsCurrentAccount = false;
            }

            // 设置新的当前账户
            account.IsCurrentAccount = true;
            _currentAccount = account;

            // 更新当前账户显示
            txtCurrentAccount.Text = account.Username;
        }

        private void AccountsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedAccount = AccountsGrid.SelectedItem as Account;
            EditAccountBtn.IsEnabled = _selectedAccount != null;
            DeleteAccountBtn.IsEnabled = _selectedAccount != null;
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AccountDialog();
            if (dialog.ShowDialog() == true)
            {
                var newAccount = new Account(dialog.Username, dialog.Password);
                Accounts.Add(newAccount);
            }
        }

        private void EditAccount_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedAccount == null) return;

            var dialog = new AccountDialog(_selectedAccount.Username, _selectedAccount.Password);
            if (dialog.ShowDialog() == true)
            {
                _selectedAccount.Username = dialog.Username;
                _selectedAccount.Password = dialog.Password;
                _selectedAccount.IsLoggedIn = false; // 重置登录状态
                _selectedAccount.IsCurrentAccount = false; // 重置当前账户状态

                // 如果编辑的是当前账户，更新显示
                if (_selectedAccount == _currentAccount)
                {
                    txtCurrentAccount.Text = _selectedAccount.Username;
                }
            }
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedAccount == null) return;

            if (MessageBox.Show($"确定要删除账户 '{_selectedAccount.Username}' 吗?",
                "确认删除", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                // 如果删除的是当前账户，清除当前账户状态
                if (_selectedAccount == _currentAccount)
                {
                    _currentAccount = null;
                    txtCurrentAccount.Text = "无";
                }

                Accounts.Remove(_selectedAccount);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag is Account account)
            {
                bool success = account.Login();
                // 登录成功后如果没有当前账户，自动设为当前账户
                if (success)
                {
                    SetCurrentAccount(account);
                }
                MessageBox.Show(success ? "登录成功!" : "登录失败，请检查用户名和密码",
                    "登录结果", MessageBoxButton.OK,
                    success ? MessageBoxImage.Information : MessageBoxImage.Error);
            }
        }

        private void SetCurrentButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Tag is Account account)
            {
                SetCurrentAccount(account);
            }
        }

        private void BatchLogin_Click(object sender, RoutedEventArgs e)
        {
            int successCount = 0;
            int totalCount = 0;

            foreach (var account in Accounts)
            {
                if (!account.IsLoggedIn)
                {
                    totalCount++;
                    if (account.Login())
                    {
                        successCount++;
                    }
                }
            }
            // 如果没有当前账户，设置第一个已登录账户为当前账户
            if (_currentAccount == null)
            {
                var loggedInAccount = Accounts.FirstOrDefault(a => a.IsLoggedIn);
                if (loggedInAccount != null)
                {
                    SetCurrentAccount(loggedInAccount);
                }
            }
            MessageBox.Show($"批量登录完成!\n成功: {successCount} 个账户\n失败: {totalCount - successCount} 个账户",
                "批量登录结果", MessageBoxButton.OK, MessageBoxImage.Information);

            
        }

        private void LogoutAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var account in Accounts)
            {
                account.IsLoggedIn = false;
            }

            // 清除当前账户状态
            if (_currentAccount != null)
            {
                _currentAccount.IsCurrentAccount = false;
                _currentAccount = null;
                txtCurrentAccount.Text = "无";
            }

            MessageBox.Show("所有账户已登出", "操作成功", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}