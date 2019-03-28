using System.Windows;

namespace WpfApp4.ViewModel
{
    public class WindowFontSizeHelper
    {
        public WindowFontSizeHelper(Window window)
        {
            TheWindow = window;
        }

        public Window TheWindow { get; set; }
        public bool ShouldPlus { get; set; } = true;
        public void ChangeFontSize()
        {
            TheWindow.Dispatcher.Invoke(() =>
            {
                if (ShouldPlus)
                {
                    TheWindow.FontSize += 3;
                }
                else
                {
                    TheWindow.FontSize -= 3;
                }

                if (TheWindow.FontSize >= 36)
                {
                    ShouldPlus = false;
                }
                if (TheWindow.FontSize <= 12)
                {
                    ShouldPlus = true;
                }
            });
        }

        public static WindowFontSizeHelper Create(Window window)
        {
            return  new WindowFontSizeHelper(window);
        }
    }
}