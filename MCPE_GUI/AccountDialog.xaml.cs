using System.Windows;

namespace MCPE_GUI
{
    public partial class AccountDialog : Window
    {
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;

        public AccountDialog()
        {
            InitializeComponent();
        }

        public AccountDialog(string username, string password) : this()
        {
            txtUsername.Text = username;
            txtPassword.Text = password;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                MessageBox.Show("用户名不能为空", "输入错误", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}