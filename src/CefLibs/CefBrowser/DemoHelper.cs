using System.Windows.Markup;

namespace CefLibs.CefBrowser
{
    //for app project not need to ref cef sharp dll
    public class DemoHelper
    {
        public static IAddChild AppendCefBrowser(IAddChild container, string uri)
        {
            var cefConfig = CefConfig.Default;
            var chromiumWebBrowser = cefConfig.CreateChromiumWebBrowser(true);
            chromiumWebBrowser.Address = uri;
            container.AddChild(chromiumWebBrowser);
            return container;
        }
    }
}
