using System.Windows;
using System.Windows.Threading;

namespace VideoDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException1;
        }

        private void App_DispatcherUnhandledException1(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            MessageBox.Show(e.Exception.Message);
            // Prevent default unhandled exception processing
            e.Handled = true;
        }
    }
}
