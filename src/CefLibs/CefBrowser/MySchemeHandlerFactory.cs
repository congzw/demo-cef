using System;
using CefSharp;

namespace CefLibs.CefBrowser
{
    public class MySchemeHandlerFactory : ISchemeHandlerFactory
    {
        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            if (schemeName == "local")
                return new LocalFileResourceHandler();

            if (schemeName == "embedded")
                return new EmbeddedFileResourceHandler();

            throw new Exception($"Requested scheme '{schemeName}' is not known.");
        }
    }
}