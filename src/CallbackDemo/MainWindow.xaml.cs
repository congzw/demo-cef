using System.Windows;
using CallbackDemo.ViewModel;
using CefLibs.CefBrowser;

namespace CallbackDemo
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
        }

        private void CustomizeInitializeComponent()
        {
            this.BtnLoad.Click += BtnLoad_Click;
        }


        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowJs != null)
            {
                return;
            }

            MainWindowJs = new MainWindowJs();
            var demoPage = @"local://whatever/html/index.html";
            var asyncJsObject = new AsyncJsObject();
            asyncJsObject.Name = "mainWindowVo";
            asyncJsObject.BindObject = this.MainWindowJs;
            var helper = CefViewHelper.Create(asyncJsObject, demoPage);

            MainWindowJs.MainCefViewHelper = helper;
            
            GridFrontPage.Children.Clear();
            helper.AppendCefBrowser(GridFrontPage);
        }
    }
}
