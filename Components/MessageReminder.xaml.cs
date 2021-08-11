using System;
using System.Collections.Generic;
using System.ComponentModel;
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


namespace VRCMaker.Components
{
    /// <summary>
    /// MessageReminder.xaml 的交互逻辑
    /// </summary>
    public partial class MessageReminder : UserControl,IDisposable
    {
        public MessageReminder()
        {
            DataContext = this;
            InitializeComponent();
        }
        public MessageReminder(string message, MahApps.Metro.IconPacks.PackIconFontAwesomeKind icon)
        {
            Message = message;
            InitializeComponent();
            DataContext = this;
            StatusIcon.Kind = icon;
        }

        private event EventHandler<EventArgs> Closed;
        private void RaiseClosed(EventArgs e)
        {
            Closed?.Invoke(this, e);
        }

        private event EventHandler<EventArgs> Click;
        private void RaiseClick(EventArgs e)
        {
            Click?.Invoke(this, e);
        }

        private static readonly DependencyProperty MessageProperty =
    DependencyProperty.Register("Message", typeof(string), typeof(MessageReminder), new PropertyMetadata(string.Empty));

        private string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Window.GetWindow(this).Closing += OnClosing;
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            this.Visibility = Visibility.Hidden;
            Dispose();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            Dispose();
        }
    }
}
