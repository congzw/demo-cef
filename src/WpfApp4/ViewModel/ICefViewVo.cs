using CefLibs.CefBrowser;

namespace WpfApp4.ViewModel
{
    public interface ICefViewVo
    {
        CefViewHelper CefViewHelper { get; set; }
        void Activate();
        void SetUri(string uri);
    }
}
