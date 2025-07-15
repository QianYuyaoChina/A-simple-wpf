using Microsoft.Win32;
using Ookii.Dialogs;
using Ookii.Dialogs.Wpf;
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
    /// SettingsPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsPage : Page
    {
        public string gamepath => x_GamePath.Text;
        public string skinpath => x_SkinPath.Text;
        public SettingsPage()
        {
            InitializeComponent();
        }
        private string? BrowseFile()
        {
            var dialog = new VistaOpenFileDialog();
            dialog.Title = "选择皮肤文件";
            dialog.Filter = "PNG 文件 (*.png)|*.png|所有文件 (*.*)|*.*";
            if ((bool)dialog.ShowDialog())
            {
                return dialog.FileName;
            }
            return null;
        }
        private string? BrowsePath()
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "选择文件夹";
            dialog.UseDescriptionForTitle = true;
            if ((bool)dialog.ShowDialog())
            {
                return dialog.SelectedPath;
            }
            return null;
        }
        private void Browse_Gamepath_Click(object sender, RoutedEventArgs e)
        {
            string? path = BrowsePath();
            if(!string.IsNullOrEmpty(path))
            {
                x_GamePath.Text = path;
            }
            else
            {
                MessageBox.Show("请选择一个有效的路径");
            }
        }
        private void Browse_Skinpath_Click(object sender, RoutedEventArgs e)
        {
            string path = BrowseFile();
            if (!string.IsNullOrEmpty(path))
            {
                x_SkinPath.Text = path;
            }
            else
            {
                MessageBox.Show("请选择一个有效的路径");
            }
        }
    }
}
