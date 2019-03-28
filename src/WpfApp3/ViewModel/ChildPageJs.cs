using System;

namespace WpfApp3.ViewModel
{
    public class ChildPageJs
    {
        public ChildPageJs(ChildPage page)
        {
            ThePage = page;
        }

        public ChildPage ThePage { get; set; }

        PageFontSizeHelper _pageFontSizeHelper = new PageFontSizeHelper();
        public void ChangeFontSize()
        {
            _pageFontSizeHelper.Invoke(ThePage, () => ThePage.ShowMessage("FontSize: " + ThePage.FontSize));
            _pageFontSizeHelper.ChangeFontSize(ThePage);
        }
    }
}
