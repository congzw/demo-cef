using System.Windows.Controls;
using CefLibs.CefBrowser;

namespace WpfApp4.ViewModel
{
    public abstract class PanelCefViewVo : ICefViewVo
    {
        protected PanelCefViewVo(Panel panel, CefViewHelper helper)
        {
            Panel = panel;
            CefViewHelper = helper;
        }

        public Panel Panel { get; set; }
        public CefViewHelper CefViewHelper { get; set; }

        public virtual void Activate()
        {
            Panel.Children.Clear();
            CefViewHelper.AppendCefBrowser(Panel);
        }

        public void SetUri(string uri)
        {
            CefViewHelper.SetUri(uri);
        }
    }
}