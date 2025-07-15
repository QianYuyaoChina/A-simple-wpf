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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MCPE_GUI
{
    /// <summary>
    /// ChargePage.xaml 的交互逻辑
    /// </summary>
    public partial class ChargePage : Page
    {
        public string key => Key.Text;
        public ChargePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"您输入了\"{key}\"\n但是这是一个免费软件，无需充值");
        }
    }
}
