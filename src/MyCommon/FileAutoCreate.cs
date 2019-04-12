using System;
using System.IO;

namespace MyCommon
{
    public class FileAutoCreate : IFileAutoCreate
    {
        public void MakeSureFileExist(string path, byte[] content, bool autoAppendAppDomainBasePath)
        {
            var file = path;
            if (autoAppendAppDomainBasePath)
            {
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }

            if (File.Exists(file))
            {
                return;
            }

            var directoryName = Path.GetDirectoryName(file);
            if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            File.WriteAllBytes(file, content);
        }

        #region for di extensions

        private static IFileAutoCreate _resolve()
        {
            var instance = new FileAutoCreate();
            return instance;
        }

        public static Func<IFileAutoCreate> Resolve = _resolve;

        #endregion
    }

    public interface IFileAutoCreate
    {
        void MakeSureFileExist(string path, byte[] content, bool autoAppendAppDomainBasePath);
    }
}
