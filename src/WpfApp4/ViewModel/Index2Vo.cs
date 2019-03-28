using System.Windows.Controls;
using CefLibs.CefBrowser;

namespace WpfApp4.ViewModel
{
    public class Index2Vo : PanelCefViewVo
    {
        public Index2Vo(Panel panel, CefViewHelper helper, Index2Js index2Js) : base(panel, helper)
        {
            Index2Js = index2Js;
        }

        public Index2Js Index2Js { get; set; }
    }

    public class Index2Js
    {
        public Index2Js(MainWindow window)
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

        public void Navigate(string name)
        {
            TheWindow.Dispatcher.Invoke(() =>
            {
                var pageVoHolder = CefViewVoHolder.Instance;
                if (!pageVoHolder.CefViewVos.ContainsKey(name))
                {
                    return;
                }

                var pageVo = pageVoHolder.CefViewVos[name];
                pageVo.Activate();
            });
        }
    }
}