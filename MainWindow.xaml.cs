using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VRCMaker.Theme;

namespace VRCMaker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Close.AddHandler(Image.MouseDownEvent, new RoutedEventHandler(Window_Close), true);
            Minimize.AddHandler(Image.MouseDownEvent, new RoutedEventHandler(Window_Minimize), true);
            WindowBlur.SetIsEnabled(this, true);
            ResourceDictionary resource = new ResourceDictionary();
            resource.Source = new Uri("pack://application:,,,/VRCMaker;component/Theme/DarkTheme.xaml");
            Application.Current.Resources = resource;
            NavigateToWelcome();
        }
        #region 标题栏事件
        ///<summary>
        ///鼠标移动
        ///</summary>
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtonState.Pressed == e.LeftButton)
                this.DragMove();
        }
        private void Window_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Minimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion
        private void NavigateToWelcome()
        {
            MainFrame.Navigate(new Uri("Pages/Welcome.xaml", UriKind.Relative));
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
