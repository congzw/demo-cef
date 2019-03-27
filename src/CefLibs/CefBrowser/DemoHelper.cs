using System.Windows.Markup;

namespace CefLibs.CefBrowser
{
    //for app project not need to ref cef sharp dll
    public class DemoHelper
    {
        public static IAddChild AppendCefBrowser(IAddChild container, string uri, AsyncJsObject asyncJsObject)
        {
            var cefConfig = CefConfig.Default;
            var chromiumWebBrowser = cefConfig.CreateChromiumWebBrowser(true, asyncJsObject);
            chromiumWebBrowser.Address = uri;
            container.AddChild(chromiumWebBrowser);
            return container;
        }
    }
}
