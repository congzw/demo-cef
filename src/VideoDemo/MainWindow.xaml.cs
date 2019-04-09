using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (_playing)
            {
                ShowMessage("playing, wait!");
                return;
            }
            CreateAndPlay();
        }
        
        private void ShowMessage(string message)
        {
            //MessageBox.Show(message);
            this.TxtMessage.Text = message;
            this.TxtMessage.Visibility = Visibility.Visible;
        }
        
        //解决多次播放的问题
        private bool _playing = false;
        private void CreateAndPlay()
        {
            _playing = true;
            var mediaElement = new MediaElement();
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.UnloadedBehavior = MediaState.Close;
            mediaElement.Source = new Uri("video/small.mp4", UriKind.Relative);
            mediaElement.Stretch = Stretch.Fill;

            mediaElement.MediaOpened += (sender, args) =>
            {
                ShowMessage("MediaOpened");
            };

            mediaElement.MediaEnded += (sender, args) =>
            {
                ShowMessage("MediaEnded");
                MyContainer.Children.Remove(mediaElement);
                mediaElement = null;
                _playing = false;
            };

            mediaElement.MediaFailed += (sender, args) =>
            {
                ShowMessage("MediaFailed" + args.ErrorException.Message);
            };

            MyContainer.Children.Add(mediaElement);
            mediaElement.Play();
        }
    }
}
