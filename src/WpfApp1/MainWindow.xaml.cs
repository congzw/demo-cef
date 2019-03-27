using System;
using System.Windows;
using CefLibs.CefBrowser;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public CefViewHelper Helper { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CustomizeInitializeComponent();
        }

        private void CustomizeInitializeComponent()
        {
            this.BtnLoad.Click += BtnLoad_Click;
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (Helper == null)
            {
                var demoPage = @"local://whatever/html/index.html";
                Helper = CefViewHelper.Create(null, demoPage);
            }

            GridFrontPage.Children.Clear();
            Helper.AppendCefBrowser(GridFrontPage);
        }
    }
}
