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
    /// Directly_Connect.xaml 的交互逻辑
    /// </summary>
    public partial class Directly_Connect : Window
    {
        public Directly_Connect()
        {
            InitializeComponent();
        }
        private void FASTHYT(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void FASTBJD(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void FASTEC(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void FASTZLF(object sender, RoutedEventArgs e)
        {
            Close();
            var dialog = new ZLF_CONN();
            if (dialog.ShowDialog() == true)
            {
                
            }
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
