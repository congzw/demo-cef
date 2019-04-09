using System.Windows;
using CefLibs;
using CefLibs.CefBrowser;

namespace KeyDemo
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
            this.BtnInfo.Click += BtnInfo_Click;
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            var environmentHelper = new EnvironmentHelper();
            var environmentInfo = environmentHelper.CreateEnvironmentInfo();
            MessageBox.Show(environmentInfo.ToString());
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
