using System;
using System.Windows;
using XamlAnimatedGif;

namespace GifDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.BtnChange.Click += BtnChange_Click;
        }

        private int index = 0;
        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            index++;
            var picIndex = index % 2 + 1;
            var picPath = AppDomain.CurrentDomain.BaseDirectory + $"Images\\Loading{picIndex:00}.gif";
            //Console.WriteLine(picPath);
            AnimationBehavior.SetSourceUri(ImgLoading, new Uri(picPath, UriKind.Absolute));
        }
    }
}
