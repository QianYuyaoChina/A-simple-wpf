// LoginWindow.xaml.cs
using MCPE_GUI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MCPE_GUI
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            SetupPlaceholders();
        }

        private void SetupPlaceholders()
        {
            // 设置用户名文本框占位符
            txtUsername.GotFocus += (s, e) => {
                if (txtUsername.Text == "")
                    txtUsername.Text = "";
            };

            txtUsername.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                    txtUsername.Text = "";
            };

            // 设置密码框占位符（自定义实现）
            txtPassword.GotFocus += (s, e) => {
                if (txtPassword.Password == "")
                    txtPassword.Password = "";
            };

            txtPassword.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtPassword.Password))
                    txtPassword.Password = "";
            };

            // 初始化占位符
            txtUsername.Text = "";
            txtPassword.Password = "";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (CheckLoginSuccess(username, password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                lblTitle.Content = "请重试";
                lblTitle.Foreground = Brushes.Red;
                txtPassword.Password = "";
            }
        }

        private bool CheckLoginSuccess(string username, string password)
        {
            // 这里实现您的真实登录验证逻辑
            // 示例默认实现：用户名为"admin"，密码为"123456"
            return true;
        }
    }
}