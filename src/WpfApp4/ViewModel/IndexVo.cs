using System.Windows.Controls;
using CefLibs.CefBrowser;

namespace WpfApp4.ViewModel
{
    public class IndexVo : PanelCefViewVo
    {
        public IndexVo(Panel panel, CefViewHelper helper, IndexJs indexJs) : base(panel, helper)
        {
            IndexJs = indexJs;
        }

        public IndexJs IndexJs { get; set; }
    }

    public class IndexJs
    {
        public IndexJs(MainWindow window)
        {
            TheWindow = window;
            _pageFontSizeHelper = WindowFontSizeHelper.Create(TheWindow);
        }
        
        private readonly WindowFontSizeHelper _pageFontSizeHelper = null;
        public MainWindow TheWindow { get; set; }

        public void ChangeFontSize()
        {
            _pageFontSizeHelper.ChangeFontSize();
        }

        public void Navigate(string cefViewName)
        {
            TheWindow.Dispatcher.Invoke(() =>
            {
                var pageVoHolder = CefViewVoHolder.Instance;
                if (!pageVoHolder.CefViewVos.ContainsKey(cefViewName))
                {
                    return;
                }

                var pageVo = pageVoHolder.CefViewVos[cefViewName];
                pageVo.Activate();
            });
        }
    }
}