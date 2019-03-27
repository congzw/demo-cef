using System;
using System.Windows.Markup;
using CefSharp.Wpf;

namespace CefLibs.CefBrowser
{
    //for app project not need to ref cef sharp dll
    public class CefViewHelper
    {
        internal ChromiumWebBrowser Browser { get; set; }

        public void InitCefBrowser(AsyncJsObject asyncJsObject, string uri)
        {
            var cefConfig = CefConfig.Default;
            Browser = cefConfig.CreateChromiumWebBrowser(true, asyncJsObject);
            Browser.Address = uri;
        }

        public void SetUri(string uri)
        {
            if (Browser == null)
            {
                throw new InvalidOperationException("必须先InitCefBrowser，然后才能使用");
            }
            Browser.Address = uri;
        }

        public IAddChild AppendCefBrowser(IAddChild container)
        {
            if (Browser == null)
            {
                throw new InvalidOperationException("必须先InitCefBrowser，然后才能使用");
            }
            container.AddChild(Browser);
            return container;
        }

        public static CefViewHelper Create(AsyncJsObject asyncJsObject, string uri)
        {
            var cefViewHelper = new CefViewHelper();
            cefViewHelper.InitCefBrowser(asyncJsObject, uri);
            return cefViewHelper;
        }
    }
}
