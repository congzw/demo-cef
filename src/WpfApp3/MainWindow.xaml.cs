using System.Windows;

namespace WpfApp3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.BtnNavigation.Click += BtnNavigation_Click;
        }

        private bool _showMain = true;
        private void BtnNavigation_Click(object sender, RoutedEventArgs e)
        {
            var name = _showMain ? "main" : "child";
            PageHolder.Instance.Navigate(MainFrame, name);
            _showMain = !_showMain;
        }
    }
}
