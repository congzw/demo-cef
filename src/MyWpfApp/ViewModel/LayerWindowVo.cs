using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyWpfApp.ViewModel
{
    public class LayerWindowVo
    {
        public LayerWindowVo(LayerWindow layer)
        {
            Layer = layer;
        }
        
        public LayerWindow Layer { get; set; }

        public void Init()
        {
            Layer.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Layer.Loaded += Layer_Loaded;
            Layer.BtnChange.Click += BtnChange_Click;
        }

        private void Layer_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private bool _showFront = true;
        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            _showFront = !_showFront;
            if (_showFront)
            {
                ShowFront();
                return;
            }
            ShowBackground();
        }

        public void ShowBackground()
        {
            //Panel.SetZIndex(Layer.GridFront, 0);
            //Panel.SetZIndex(Layer.GridBackground, 1);

            Layer.GridFront.Visibility = Visibility.Collapsed;
            Layer.GridBackground.Visibility = Visibility.Visible;
        }

        public void ShowFront()
        {
            //Panel.SetZIndex(Layer.GridFront, 1);
            //Panel.SetZIndex(Layer.GridBackground, 0);

            Layer.GridFront.Visibility = Visibility.Visible;
            Layer.GridBackground.Visibility = Visibility.Collapsed;
        }
    }
}
