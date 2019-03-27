using System.Windows;
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
        public CefViewHelper Helper { get; set; }

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
            if (Helper == null)
            {
                var demoPage = @"local://whatever/html/index.html";
                var asyncJsObject = new AsyncJsObject();
                asyncJsObject.Name = "mainWindowVo";
                asyncJsObject.BindObject = this.MainWindowJs;
                Helper = CefViewHelper.Create(asyncJsObject, demoPage);
            }

            GridFrontPage.Children.Clear();
            Helper.AppendCefBrowser(GridFrontPage);
        }
    }
}
