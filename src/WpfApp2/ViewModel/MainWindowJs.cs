using System;
using System.Windows;
using System.Windows.Media;

namespace WpfApp2.ViewModel
{
    public class MainWindowJs
    {
        public MainWindow TheWindow { get; }

        public MainWindowJs(MainWindow mainWindow)
        {
            TheWindow = mainWindow;
        }

        public void ShowMessage(string message)
        {
            TheWindow.Dispatcher.Invoke(() =>
                MessageBox.Show("Message from browser: " + message, "System.MessageBox"));
        }

        public void ChangeColor()
        {
            TheWindow.Dispatcher.Invoke(() =>
            {
                if (TheWindow.GridFrontPage.Background != Brushes.Green)
                {
                    TheWindow.GridFrontPage.Background = Brushes.Green;
                }
                else
                {
                    TheWindow.GridFrontPage.Background = Brushes.Transparent;
                }
            });
        }
    }
}
