using System.Windows.Controls;

namespace WpfApp3
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        public static int InvokeCount = 0;
        public MainPage()
        {
            InitializeComponent();
            InvokeCount++;
            this.Message.Text = "MainPage: " + InvokeCount;
        }
    }
}
