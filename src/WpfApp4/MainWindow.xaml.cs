using System.Windows;
using CefLibs.CefBrowser;
using WpfApp4.ViewModel;

namespace WpfApp4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CustomizeInitializeComponent();
        }

        private void CustomizeInitializeComponent()
        {
            var pageVoHolder = CefViewVoHolder.Instance;

            var indexUri = @"local://whatever/html/index.html";
            var indexJs = new IndexJs(this);
            var asyncJsObject = new AsyncJsObject();
            asyncJsObject.Name = "cefHost";
            asyncJsObject.BindObject = indexJs;
            var cefViewHelper = CefViewHelper.Create(asyncJsObject, indexUri);

            var indexVo = new IndexVo(GridFrontPage, cefViewHelper, indexJs);
            pageVoHolder.CefViewVos.Add("IndexVo", indexVo);

            var index2Uri = @"local://whatever/html/index2.html";
            var index2Js = new Index2Js(this);
            var index2AsyncJsObject = new AsyncJsObject();
            index2AsyncJsObject.Name = "cefHost";
            index2AsyncJsObject.BindObject = index2Js;
            var index2CefViewHelper = CefViewHelper.Create(index2AsyncJsObject, index2Uri);

            var index2Vo = new Index2Vo(GridFrontPage, index2CefViewHelper, index2Js);
            pageVoHolder.CefViewVos.Add("Index2Vo", index2Vo);

            BtnLoad.Click += BtnLoad_Click;
        }

        private bool _currentIsIndexVo = true;
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            var pageVoHolder = CefViewVoHolder.Instance;
            var currentVo = _currentIsIndexVo ? "IndexVo" : "Index2Vo";
            IndexVo vo = (IndexVo)pageVoHolder.CefViewVos[currentVo];
            vo.Activate();
            _currentIsIndexVo = !_currentIsIndexVo;
        }
    }
}
