using System.Windows;

namespace MCPE_GUI
{
    public partial class GamesDialog : Window
    {
        public string Username => txtUsername.Text;

        public GamesDialog()
        {
            InitializeComponent();
        }

        public GamesDialog(string username) : this()
        {
            txtUsername.Text = username;
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