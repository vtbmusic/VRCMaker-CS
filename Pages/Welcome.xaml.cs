using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using VRCMaker.Service;

namespace VRCMaker.Pages
{
    /// <summary>
    /// Welcome.xaml 的交互逻辑
    /// </summary>
    public partial class Welcome : Page
    {
        public Welcome()
        {
            InitializeComponent();
            Loading.Visibility = Visibility.Hidden;
            LoadingText.Visibility = Visibility.Hidden;
        }

        private async void Welcomes_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(1800);
            Loading.Visibility = Visibility.Visible;
            WelcomeSlogan.Visibility = Visibility.Hidden;
            LoadingText.Visibility = Visibility.Visible;
            LoadingText.Text = "请稍后";
            await Task.Delay(1500);
            LoadingText.Text = "我们正在与API取得连接...";
            LoadingText.Text = (await APITools.CheckConnection() == "Successful") ? "连接成功，正在载入" : "连接失败，正在进入离线模式";
            await Task.Delay(1000);
            NavigationService.GetNavigationService(this).Navigate(new Home());
        }
    }
}
