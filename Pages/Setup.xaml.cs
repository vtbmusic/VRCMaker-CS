using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VRCMaker.Pages.SetupPages;

namespace VRCMaker.Pages
{
    /// <summary>
    /// Setup.xaml 的交互逻辑
    /// </summary>
    public partial class Setup : Page
    {
        public Setup()
        {
            InitializeComponent();
            NavigateToWelcome();
        }
        private void NavigateToWelcome()
        {
            SetupFrame.Navigate(new WelcomePage());
        }
    }
}
