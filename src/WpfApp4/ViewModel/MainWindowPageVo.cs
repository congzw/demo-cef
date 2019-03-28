using CefLibs.CefBrowser;

namespace WpfApp3.ViewModel
{
    public class MainWindowPageVo
    {
        public MainWindowPageVo(MainWindowPage window)
        {
            TheWindow = window;
        }

        public MainWindowPage TheWindow { get; set; }
    }

    public class MainPageVo
    {
        public MainPageJs Js { get; set; }
        public CefViewHelper Helper { get; set; }

        public static MainPageVo InitCefView(string entryUri)
        {
            new MainPageJs();
            var asyncJsObject = new AsyncJsObject();
            asyncJsObject.Name = "cefHost";
            var Vo = new MainWindowPageVo(this);
            asyncJsObject.BindObject = Vo;


            var mainPageVo = new MainPageVo();
            Helper = CefViewHelper.Create(asyncJsObject, entryUri);
        }

        //private void InitCefView()
        //{
        //    if (Helper == null)
        //    {
        //        var entryUri = @"local://whatever/html/index.html";
        //        var asyncJsObject = new AsyncJsObject();
        //        asyncJsObject.Name = "cefHost";
        //        Vo = new MainWindowPageVo(this);
        //        asyncJsObject.BindObject = Vo;
        //        Helper = CefViewHelper.Create(asyncJsObject, entryUri);
        //    }

        //    GridFrontPage.Children.Clear();
        //    Helper.AppendCefBrowser(GridFrontPage);
        //}
    }

    public class ChildPageVo
    {
        public ChildPageJs Js { get; set; }
        public CefViewHelper Helper { get; set; }
    }

    public class MainPageVoJs
    {

    }
}
