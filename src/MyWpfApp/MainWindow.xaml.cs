using System.Windows;
using MyWpfApp.ViewModel;

namespace MyWpfApp
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

        public MainWindowVo Vo { get; set; }

        private void CustomizeInitializeComponent()
        {
            Vo = new MainWindowVo(this);
            Vo.Init();
        }
    }
}
