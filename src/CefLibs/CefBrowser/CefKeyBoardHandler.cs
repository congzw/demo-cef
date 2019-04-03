using System;
using CefSharp;

namespace CefLibs.CefBrowser
{
    internal class CefKeyBoardHandler : IKeyboardHandler
    {
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
            //todo 使用System.Windows.Input.Key.F12来实现
            //目前windowsKeyCode和System.Windows.Input.Key.F12无法对应 没有深入研究
            if (windowsKeyCode == 123 && type == KeyType.KeyUp)
            {
                browser.ShowDevTools();
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
