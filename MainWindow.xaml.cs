using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using VRCMaker.Model;

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
        }

        #region 数据绑定

        private void NavigationBar_Loaded(object sender, RoutedEventArgs e)
        {
            List<NavigationBarModel> navigations = new List<NavigationBarModel>();
            navigations.Add(new NavigationBarModel {Imagesource= (ImageSource)new ImageSourceConverter().ConvertFromString("https://cloud.alphaly.net/api/v3/file/get/11/%E4%B8%BB%E9%A1%B5.png?sign=jWZ_4lZcUVWfKbJMLvsfB4CZNJGEdoe1UNo7p3x9Eyc%3D%3A0") ,Text="主页"});
            navigations.Add(new NavigationBarModel { Imagesource = (ImageSource)new ImageSourceConverter().ConvertFromString("https://cloud.alphaly.net/api/v3/file/get/11/%E4%B8%BB%E9%A1%B5.png?sign=jWZ_4lZcUVWfKbJMLvsfB4CZNJGEdoe1UNo7p3x9Eyc%3D%3A0"), Text = "主页" });
            NavigationBar.ItemsSource = navigations;
        }

        #endregion
    }
}
