using System;
using VRCMaker.Controllers;

namespace VRCMaker.Window
{
    /// <summary>
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings
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