using System.Windows;
using System.Windows.Controls;

namespace VideoDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.PlayButton.Click += PlayButton_Click;
            this.DemoVideo.MediaOpened += DemoVideo_MediaOpened;
            this.DemoVideo.MediaFailed += DemoVideo_MediaFailed;
            this.DemoVideo.MediaEnded += DemoVideo_MediaEnded;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            this.DemoVideo.LoadedBehavior = MediaState.Manual;
            this.DemoVideo.Visibility = Visibility.Visible;
            this.DemoVideo.Play();
        }

        private void DemoVideo_MediaOpened(object sender, RoutedEventArgs e)
        {
            ShowMessage("MediaOpened");
        }

        private void DemoVideo_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            ShowMessage("MediaFailed" + e.ErrorException.Message);
        }

        private void DemoVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            ShowMessage("MediaEnded");
            this.DemoVideo.Visibility = Visibility.Collapsed;
        }

        private void ShowMessage(string message)
        {
            this.TxtMessage.Text = message;
            this.TxtMessage.Visibility = Visibility.Visible;
        }
    }
}
