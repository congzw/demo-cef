using System.Windows;
using System.Windows.Media;
using CefLibs.CefBrowser;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowJs MainWindowJs { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CustomizeInitializeComponent();
            MainWindowJs = new MainWindowJs(this);
        }

        private void CustomizeInitializeComponent()
        {
            this.BtnLoad.Click += BtnLoad_Click;
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            GridFrontPage.Children.Clear();
            var demoPage = @"local://whatever/html/index.html";
            var asyncJsObject = new AsyncJsObject();
            asyncJsObject.Name = "mainWindowVo";
            asyncJsObject.BindObject = this.MainWindowJs;
            DemoHelper.AppendCefBrowser(GridFrontPage, demoPage, asyncJsObject);
        }
    }
}
