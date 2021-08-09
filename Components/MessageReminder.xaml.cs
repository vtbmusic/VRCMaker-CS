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
using static VRCMaker.Model.MRIcons;

namespace VRCMaker.Components
{
    /// <summary>
    /// MessageReminder.xaml 的交互逻辑
    /// </summary>
    public partial class MessageReminder : UserControl
    {
        public MessageReminder()
        {
            DataContext = this;
            InitializeComponent();
        }
        private static readonly DependencyProperty IconProperty =
    DependencyProperty.Register("Icon", typeof(MessageReminderIcons), typeof(MessageReminder), new PropertyMetadata(MessageReminderIcons.None));

        private MessageReminderIcons Icon
        {
            get { return (MessageReminderIcons)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}
