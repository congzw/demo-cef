using System.Windows;
using CefLibs.CefBrowser;
using MyWpfApp.Traces;

namespace MyWpfApp
{
    /// <summary>
    /// TraceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TraceWindow : Window
    {
        public CefViewHelper Helper { get; set; }
        public JaegerHelper JaegerHelper { get; set; }

        public TraceWindow()
        {
            InitializeComponent();
            CustomizeInitializeComponent();
        }

        private void CustomizeInitializeComponent()
        {
            JaegerHelper = new JaegerHelper(new CmdHelper());
            var demoPage = @"local://whatever/html/empty.html";
            Helper = CefViewHelper.Create(null, demoPage);
            GridFrontPage.Children.Clear();
            Helper.AppendCefBrowser(GridFrontPage);

            this.BtnStart.Click += BtnStart_Click;
            this.BtnStop.Click += BtnStop_Click;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            JaegerHelper.Start();
            Helper.SetUri(@"http://localhost:16686");
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            JaegerHelper.Stop();
            Helper.SetUri(@"local://whatever/html/empty.html");
        }
    }
}
