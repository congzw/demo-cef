using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MyResources;

namespace MyWpfApp.ViewModel
{
    public class MainWindowVo
    {
        public MainWindowVo(MainWindow main)
        {
            Main = main;
        }

        public MainWindow Main { get; set; }
        
        public void Init()
        {
            ResourceFileHelper.MakeSureResourcesExist();

            Main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Main.Loaded += Main_Loaded;
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            ShowBackground();
            CreateAndPlay(Main.GridBackground, ResourceFileHelper.SmallMp4, ShowFront);
        }

        public void ShowBackground()
        {
            Panel.SetZIndex(Main.GridFront, 0);
            Panel.SetZIndex(Main.GridBackground, 1);
            
            Main.GridFront.Visibility = Visibility.Collapsed;
            Main.GridBackground.Visibility = Visibility.Visible;
        }

        public void ShowFront()
        {
            Panel.SetZIndex(Main.GridFront, 1);
            Panel.SetZIndex(Main.GridBackground, 0);
            Main.GridFront.Visibility = Visibility.Visible;
            Main.GridBackground.Visibility = Visibility.Collapsed;
        }

        //解决多次播放的问题
        internal bool _playing = false;
        public void CreateAndPlay(Panel panel, string videoUri, Action completeCallback)
        {
            _playing = true;
            var mediaElement = new MediaElement();
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.UnloadedBehavior = MediaState.Close;
            mediaElement.Source = new Uri(videoUri, UriKind.Relative);
            mediaElement.Stretch = Stretch.Fill;

            mediaElement.MediaOpened += (sender, args) =>
            {
                ShowMessage("MediaOpened");
            };

            mediaElement.MediaEnded += (sender, args) =>
            {
                ShowMessage("MediaEnded");
                ClearVideo(ref panel, ref mediaElement);
                completeCallback?.Invoke();
            };

            mediaElement.MediaFailed += (sender, args) =>
            {
                ShowMessage("MediaFailed" + args.ErrorException.Message);
                ClearVideo(ref panel, ref mediaElement);
                completeCallback?.Invoke();
            };

            panel.Children.Add(mediaElement);
            mediaElement.Play();
        }
        
        private void ClearVideo(ref Panel panel, ref MediaElement mediaElement)
        {
            panel.Children.Remove(mediaElement);
            mediaElement = null;
            _playing = false;
        }

        private void ShowMessage(string message)
        {
            Main.TxtMessage.Text = message;
            Main.TxtMessage.Visibility = Visibility.Visible;
        }
    }
}
