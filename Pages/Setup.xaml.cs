using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            PreviousButton.AddHandler(Button.MouseDownEvent, new RoutedEventHandler(NavigateToPrevious), true);
            NextButton.AddHandler(Button.MouseDownEvent, new RoutedEventHandler(NavigateToNext), true);
            PageInit();
            NavigateToWelcome();
        }
        Page[] SetupPages = new Page[5];
        private void PageInit()
        {
            SetupPages[0] = new WelcomePage();
            SetupPages[1] = new AccountSettingPage();
            SetupPages[2] = new AccountSettingPage();
            SetupPages[3] = new AccountSettingPage();
            SetupPages[4] = new AccountSettingPage();
        }
        int PageNumber = 0;
        private void NavigateToNext(object sender, RoutedEventArgs e)
        {
            if (PageNumber <= 3)
            {
                PageNumber++;
                SetupFrame.Navigate(SetupPages[PageNumber]);
                PreviousButtonContent.Text = PageNumber == 0 ? "了解更多" : "上一步";
            }
            NextButtonContent.Text = PageNumber == 4 ? "完成" : "下一步";
        }
        private void NavigateToPrevious(object sender, RoutedEventArgs e)
        {
            if (PageNumber != 0)
            {
                PageNumber--;
                SetupFrame.Navigate(SetupPages[PageNumber]);
                PreviousButtonContent.Text = PageNumber == 0 ? "了解更多" : "上一步";
            }
            NextButtonContent.Text = PageNumber == 4 ? "完成" : "下一步";
        }
        private void NavigateToWelcome()
        {
            SetupFrame.Navigate(SetupPages[0]);
        }
    }
}
