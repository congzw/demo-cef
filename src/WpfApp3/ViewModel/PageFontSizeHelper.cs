using System;
using System.Windows.Controls;

namespace WpfApp3.ViewModel
{
    public class PageFontSizeHelper
    {
        public bool ShouldPlus { get; set; } = true;
        public void ChangeFontSize(Page page)
        {
            page.Dispatcher.Invoke(() =>
            {
                if (ShouldPlus)
                {
                    page.FontSize += 3;
                }
                else
                {
                    page.FontSize -= 3;
                }

                if (page.FontSize >= 36)
                {
                    ShouldPlus = false;
                }
                if (page.FontSize <= 12)
                {
                    ShouldPlus = true;
                }
            });
        }

        public void Invoke(Page page, Action action)
        {
            page.Dispatcher.Invoke(action);
        }
    }
}