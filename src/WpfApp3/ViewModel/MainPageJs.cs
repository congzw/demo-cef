using System;

namespace WpfApp3.ViewModel
{
    public class MainPageJs
    {
        public MainPageJs(MainPage page)
        {
            ThePage = page;
        }

        public MainPage ThePage { get; set; }

        PageFontSizeHelper _pageFontSizeHelper = new PageFontSizeHelper();
        public void ChangeFontSize()
        {
            _pageFontSizeHelper.Invoke(ThePage, () => ThePage.ShowMessage("FontSize: " + ThePage.FontSize));
            _pageFontSizeHelper.ChangeFontSize(ThePage);
        }
    }
}