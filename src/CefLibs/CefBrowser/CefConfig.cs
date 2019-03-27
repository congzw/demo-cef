using System;
using System.IO;
using System.Reflection;
using CefSharp;
using CefSharp.Wpf;

namespace CefLibs.CefBrowser
{
    public class CefConfig
    {
        public bool Initialized { get; set; }

        public ChromiumWebBrowser CreateChromiumWebBrowser(bool autoInit, AsyncJsObject asyncJsObject)
        {
            if (!Initialized)
            {
                if (!autoInit)
                {
                    throw new InvalidOperationException("Cef is not be initialized!");
                }

                var defaultCefSettings = CreateDefaultCefSettings();
                Init(defaultCefSettings);
            }
            var chromiumWebBrowser = new ChromiumWebBrowser();
            if (asyncJsObject != null)
            {
                chromiumWebBrowser.RegisterAsyncJsObject(asyncJsObject.Name, asyncJsObject.BindObject, (BindingOptions)asyncJsObject.BindingOptions);
            }
            return chromiumWebBrowser;
        }

        public void Init(CefSettings cefSettings)
        {
            if (Initialized)
            {
                throw new InvalidOperationException("Cef already initialized!");
            }
            
            var initialize = Cef.Initialize(cefSettings);
            if (!initialize)
            {
                throw new Exception("Unable to Initialize Cef");
            }

            Initialized = true;
        }

        public CefSettings CreateDefaultCefSettings()
        {
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;

            var cefSettings = new CefSettings();
            cefSettings.Locale = "zh-CN";

            cefSettings.RegisterScheme(new CefCustomScheme()
            {
                SchemeName = "local",
                SchemeHandlerFactory = new MySchemeHandlerFactory(),
            });

            cefSettings.RegisterScheme(new CefCustomScheme()
            {
                SchemeName = "embedded",
                SchemeHandlerFactory = new MySchemeHandlerFactory(),
            });
            return cefSettings;
        }

        public static CefConfig Default = new CefConfig();

        #region SupportAnyCpu
        
        private static bool _resolverAutoCpu = false;
        // Will attempt to load missing assembly from either x86 or x64 subdir
        // Required by CefSharp to load the unmanaged dependencies when running using AnyCPU
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                var assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                var archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                    Environment.Is64BitProcess ? "x64" : "x86",
                    assemblyName);

                return File.Exists(archSpecificPath)
                    ? Assembly.LoadFile(archSpecificPath)
                    : null;
            }
            return null;
        }

        public static void SupportAnyCpu()
        {
            if (_resolverAutoCpu)
            {
                return;
            }
            AppDomain.CurrentDomain.AssemblyResolve += Resolver;
            _resolverAutoCpu = true;
        }

        #endregion
    }

    public class AsyncJsObject
    {
        /// <summary>
        /// The name of the object. (e.g. "foo", if you want the object to be accessible as window.foo).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The object to be made accessible to Javascript.
        /// </summary>
        public object BindObject { get; set; }

        public object BindingOptions { get; set; }
    }
}
