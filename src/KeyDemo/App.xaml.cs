using System;
using System.IO;
using System.Text;
using System.Windows;
using CefLibs.CefBrowser;

namespace KeyDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            CefConfig.SupportAnyCpu();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var message = e.Exception.Message;
            MessageBox.Show(e.Exception.Message);
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exceptions.txt");
                File.AppendAllText(path, message, Encoding.UTF8);
                File.AppendAllText(path, Environment.NewLine);
                File.AppendAllText(path, string.Format("---- {0} ----", DateTime.Now), Encoding.UTF8);
                File.AppendAllText(path, Environment.NewLine);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
