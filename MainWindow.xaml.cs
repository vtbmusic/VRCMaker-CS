using System.Windows;
using System.Windows.Controls.Primitives;
using Microsoft.Win32;
using VRCMaker.Controllers;
using VRCMaker.Window;

namespace VRCMaker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Scroll(object sender, ScrollEventArgs e)
        {
            if (!Configs.GetLyricScrollBarBind()) return;
            if (Equals(sender, oriLyric))
            {
                transLyric.ScrollToVerticalOffset(e.NewValue);
            }
            else
            {
                oriLyric.ScrollToVerticalOffset(e.NewValue);
            }
        }

        private void OpenSettingsWindow(object sender, RoutedEventArgs e)
        {
            var settings = new Settings();
            settings.ShowDialog();
        }

        private void OnOpenFileClicked(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "ass字幕文件|*.ass|所有文件|*.*", 
                FilterIndex = 0
            };
            ofd.ShowDialog();
        }
    }
}