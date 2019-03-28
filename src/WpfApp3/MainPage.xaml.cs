using System;
using System.Windows.Controls;
using CefLibs.CefBrowser;
using WpfApp3.ViewModel;

namespace WpfApp3
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        public static int InvokeCount = 0;
        public MainPage()
        {
            InitializeComponent();
            InvokeCount++;
            this.Message.Text = "MainPage: " + InvokeCount;
            InitCefView();
        }

        private void InitCefView()
        {
            if (Helper == null)
            {
                var entryUri = @"local://whatever/html/index.html";
                var asyncJsObject = new AsyncJsObject();
                asyncJsObject.Name = "cefHost";
                Js = new MainPageJs(this);
                asyncJsObject.BindObject = Js;
                Helper = CefViewHelper.Create(asyncJsObject, entryUri);
            }

            GridFrontPage.Children.Clear();
            Helper.AppendCefBrowser(GridFrontPage);
        }

        public MainPageJs Js { get; set; }
        public CefViewHelper Helper { get; set; }
        public void ShowMessage(string message)
        {
            this.Message.Text = message + " [" + DateTime.Now + "]";
        }
    }
}
