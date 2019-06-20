using System;
using System.IO;

namespace MyWpfApp.Captures
{
    internal class MyPathHelper
    {
        public static void AutoCreateDirectory(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            string dirPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirPath))
            {
                if (string.IsNullOrWhiteSpace(dirPath))
                {
                    throw new ArgumentException("非法的路径:" + filePath);
                }
                Directory.CreateDirectory(dirPath);
            }
        }
    }
}