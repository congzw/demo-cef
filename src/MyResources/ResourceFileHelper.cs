using System.Drawing;
using System.IO;
using MyCommon;

namespace MyResources
{
    public class ResourceFileHelper
    {
        public static string SmallMp4 = "Resources/small.mp4";
        public static string Loading01Gif = "Resources/Loading01.gif";
        public static string Loading02Gif = "Resources/Loading02.gif";

        public static void MakeSureResourcesExist()
        {
            MakeSureVideoExist(SmallMp4, Resources.small);
            MakeSureGifExist(Loading01Gif, Resources.Loading01);
            MakeSureGifExist(Loading02Gif, Resources.Loading02);
        }

        #region helpers

        internal static readonly IFileAutoCreate AutoFile = FileAutoCreate.Resolve();

        internal static void MakeSureVideoExist(string path, byte[] bytes)
        {
            AutoFile.MakeSureFileExist(path, bytes, true);
        }

        internal static void MakeSureGifExist(string path, Image image)
        {
            AutoFile.MakeSureFileExist(path, ImageToByteArray(image), true);
        }

        private static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        #endregion
    }
}
