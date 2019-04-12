using System.Windows;
using MyWpfApp.ViewModel;

namespace MyWpfApp
{
    /// <summary>
    /// LayerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LayerWindow : Window
    {
        public LayerWindowVo Vo { get; set; }

        public LayerWindow()
        {
            InitializeComponent();
            
            Vo = new LayerWindowVo(this);
            Vo.Init();
        }
    }
}
