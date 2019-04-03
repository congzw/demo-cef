﻿using System.Windows;
using CefLibs.CefBrowser;

namespace CallbackDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CefConfig.SupportAnyCpu();
        }
    }
}
