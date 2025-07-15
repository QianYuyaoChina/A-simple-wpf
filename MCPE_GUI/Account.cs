using System.ComponentModel;
using System.Windows.Media;

namespace MCPE_GUI
{
    public class Account : INotifyPropertyChanged
    {
        protected string _username;
        private string _password;
        protected bool _isLoggedIn;
        private bool _isCurrentAccount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                _isLoggedIn = value;
                OnPropertyChanged(nameof(IsLoggedIn));
                OnPropertyChanged(nameof(StatusText));
                OnPropertyChanged(nameof(StatusColor));
                OnPropertyChanged(nameof(RowBackground));
            }
        }

        public bool IsCurrentAccount
        {
            get => _isCurrentAccount;
            set
            {
                _isCurrentAccount = value;
                OnPropertyChanged(nameof(IsCurrentAccount));
                OnPropertyChanged(nameof(StatusText));
                OnPropertyChanged(nameof(StatusColor));
                OnPropertyChanged(nameof(RowBackground));
            }
        }

        public string StatusText
        {
            get
            {
                if (IsCurrentAccount) return "当前账户";
                return IsLoggedIn ? "已登录" : "未登录";
            }
        }

        public Brush StatusColor
        {
            get
            {
                if (IsCurrentAccount) return Brushes.Blue;
                return IsLoggedIn ? Brushes.Green : Brushes.Red;
            }
        }

        public Brush RowBackground
        {
            get
            {
                if (IsCurrentAccount) return new SolidColorBrush(Color.FromArgb(30, 30, 144, 255)); // 浅蓝色背景
                return Brushes.Transparent;
            }
        }

        public Account(string username, string password)
        {
            Username = username;
            Password = password;
            IsLoggedIn = false;
            IsCurrentAccount = false;
        }

        public bool Login()
        {
            // 这里实现您的真实登录验证逻辑
            // 示例默认实现：用户名为"admin"，密码为"123456"
            bool success = true;

            if (success)
            {
                IsLoggedIn = true;
            }

            return success;
        }

        public void SetAsCurrentAccount()
        {
            IsCurrentAccount = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}