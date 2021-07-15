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

namespace VRCMaker
{
    /// <summary>
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings : Window
    {

        public Settings()
        {
            InitializeComponent();
            LyricScroll.IsChecked = Configs.GetLyricScrollBarBind();
        }

        private void LyricScrollBind(object sender, EventArgs e)
        {
            Configs.SetLyricScrollBarBind(true);
        }

        private void LyricScrollUnBind(object sender, EventArgs e)
        {
            Configs.SetLyricScrollBarBind(false);
        }
    }
}
