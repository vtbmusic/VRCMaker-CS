using HandyControl.Controls;
using Notifications.Wpf;
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
using VRCMaker.Components;

namespace VRCMaker.Pages.SetupPages
{
    /// <summary>
    /// AccountSettingPage.xaml 的交互逻辑
    /// </summary>
    public partial class AccountSettingPage : Page
    {
        public AccountSettingPage()
        {
            InitializeComponent();
            LoginButton.AddHandler(Button.MouseDownEvent, new RoutedEventHandler(Login),true);
            Message.Children.Add(new MessageReminder("登录成功", MahApps.Metro.IconPacks.PackIconFontAwesomeKind.CheckSolid));
        }
        private void Login(object sender,RoutedEventArgs e)
        {
            var notificationManager = new NotificationManager();

            notificationManager.Show(new NotificationContent
            {
                Title = "登录成功",
                Message = "你好！Alphaly",
                Type = NotificationType.Information
            });

        }
    }
}
