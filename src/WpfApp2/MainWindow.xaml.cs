using System.Windows;
using CefLibs.CefBrowser;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
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
            GridFrontPage.Children.Clear();
            var demoPage = @"local://whatever/html/index.html";
            DemoHelper.AppendCefBrowser(GridFrontPage, demoPage);
        }
    }
}
