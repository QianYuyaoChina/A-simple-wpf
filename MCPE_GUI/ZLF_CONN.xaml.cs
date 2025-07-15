using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MCPE_GUI
{
    /// <summary>
    /// ZLF_CONN.xaml 的交互逻辑
    /// </summary>
    public partial class ZLF_CONN : Window
    {
        public string Username => txtUsername.Text;
        public string Password => txtPassword.Text;

        public ZLF_CONN()
        {
            InitializeComponent();
        }

        public ZLF_CONN(string username, string password) : this()
        {
            txtUsername.Text = username;
            txtPassword.Text = password;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                MessageBox.Show("ID不能为空", "输入错误", MessageBoxButton.OK, MessageBoxImage.Warning);
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
