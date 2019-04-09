using System;
using CefSharp;

namespace CefLibs.CefBrowser
{
    internal class CefKeyBoardHandler : IKeyboardHandler
    {
        public static int F5KeyCode = 116;
        public static int F12KeyCode = 123;

        /// <summary>
        /// 实现F12调出调试窗口
        /// </summary>
        /// <param name="browserControl"></param>
        /// <param name="browser"></param>
        /// <param name="type"></param>
        /// <param name="windowsKeyCode"></param>
        /// <param name="nativeKeyCode"></param>
        /// <param name="modifiers"></param>
        /// <param name="isSystemKey"></param>
        /// <returns></returns>
        public bool OnKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            if (type != KeyType.KeyUp)
            {
                return false;
            }

            //todo 使用System.Windows.Input.Key.F12来实现
            //目前windowsKeyCode和System.Windows.Input.Key.F12无法对应 没有深入研究
            if (windowsKeyCode == F12KeyCode)
            {
                Console.WriteLine("F12");
                browser.ShowDevTools();
                return true;
            }

            if (windowsKeyCode == F5KeyCode)
            {
                Console.WriteLine("F5");
                if (browser.MainFrame?.Url != null)
                {
                    if (browser.MainFrame.Url.StartsWith("chrome-devtools:", StringComparison.OrdinalIgnoreCase))
                    {
                        //chrome-devtools://devtools/devtools_app.html
                        return false;
                    }
                }

                browser.Reload(true);
                return true;
            }

            return false;
        }

        public bool OnPreKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return false;
        }
    }
}
