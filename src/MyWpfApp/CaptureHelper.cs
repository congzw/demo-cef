using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyWpfApp
{
    internal class CaptureHelper
    {
        public static void Save(PngBitmapEncoder encoder, string filePath)
        {
            //OpenRead => solve another process using problems:
            using (Stream fs = File.OpenWrite(filePath))
            {
                encoder.Save(fs);
                fs.Flush();
                fs.Close();
            }

            //using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            //{
            //    encoder.Save(fs);
            //    fs.Flush();
            //    fs.Close();
            //}
        }

        public static PngBitmapEncoder Capture(FrameworkElement element)
        {
            var rect = VisualTreeHelper.GetDescendantBounds(element);
            var dv = new DrawingVisual();
            using (var ctx = dv.RenderOpen())
            {
                var brush = new VisualBrush(element);
                ctx.DrawRectangle(brush, null, new Rect(rect.Size));
            }

            // Make a bitmap and draw on it.
            int width = (int)element.ActualWidth;
            int height = (int)element.ActualHeight;
            var rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(dv);

            // Make a PNG encoder.
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            return encoder;
        }

        public static void CaptureTo(FrameworkElement element, string filePath)
        {
            Save(Capture(element), filePath);
        }

        //public static PngBitmapEncoder Capture(FrameworkElement element)
        //{
        //    var width = (int)element.ActualWidth;
        //    var height = (int)element.ActualWidth;
        //    var renderTargetBitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
        //    renderTargetBitmap.Render(element);
        //    var encoder = new PngBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
        //    return encoder;
        //}
    }
}