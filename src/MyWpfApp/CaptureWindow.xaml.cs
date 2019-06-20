using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using MyWpfApp.Captures;
using Point = System.Windows.Point;

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
            CaptureScreen(this.CaptureArea);
            //CaptureScreen(this.GridBackground);
            //CaptureIt(this.TheImage, "_capture.png");
            //CaptureIt(this.TheVideo, "_captureV.png");
        }

        private void CaptureIt(FrameworkElement control, string pictureName)
        {
            //capture video
            var savePng = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"_Local\html\" + pictureName);
            CaptureHelper.CaptureTo(control, savePng);
        }

        private void CaptureScreen(FrameworkElement control)
        {
            ScreenCapture.CopyControlTo(control, System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"test\CopyControlTo.png"));
            ScreenCapture.CopyScreenAreaTo(control, this, System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"test\CopyControlTo.png"), "AppendText!!!");
        }
    }
}
