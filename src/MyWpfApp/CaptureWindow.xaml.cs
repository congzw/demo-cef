using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MyWpfApp
{
    /// <summary>
    /// CaptureWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CaptureWindow : Window
    {
        public CaptureWindow()
        {
            InitializeComponent();
            this.BtnShow.Click += BtnShow_Click;
            this.BtnCapture.Click += BtnCapture_Click;
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            if (TheImage.Source == null)
            {
                var testPng = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"_Local\html\oops.png");
                TheImage.Source = new BitmapImage(new Uri(testPng));
            }

            var videoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"_Local\html\small.mp4");
            TheVideo.Source = new Uri(videoPath);
        }

        private void BtnCapture_Click(object sender, RoutedEventArgs e)
        {
            CaptureIt(this.TheImage, "_capture.png");
            CaptureIt(this.TheVideo, "_captureV.png");
        }

        private void CaptureIt(FrameworkElement control, string pictureName)
        {
            //capture video
            var savePng = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"_Local\html\" + pictureName);
            CaptureHelper.CaptureTo(control, savePng);
        }
    }
}
