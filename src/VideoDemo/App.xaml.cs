using System;
using System.IO;
using System.Text;
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
            // Prevent default unhandled exception processing
            var message = e.Exception.Message;
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
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
