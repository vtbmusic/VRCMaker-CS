using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void Scroll(object sender, ScrollEventArgs e)
        {
            if (Configs.GetLyricScrollBarBind())
            {
                if (sender == oriLyric)
                {
                    transLyric.ScrollToVerticalOffset(e.NewValue);
                }
                else
                {
                    oriLyric.ScrollToVerticalOffset(e.NewValue);
                }
            }
        }
    }
}
