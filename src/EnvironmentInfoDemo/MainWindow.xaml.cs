using System.Windows;

namespace EnvironmentInfoDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.BtnInfo.Click += BtnInfo_Click;
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            var environmentHelper = new EnvironmentHelper();
            var environmentInfo = environmentHelper.CreateEnvironmentInfo();
            MessageBox.Show(environmentInfo.ToString());
        }
    }
}
