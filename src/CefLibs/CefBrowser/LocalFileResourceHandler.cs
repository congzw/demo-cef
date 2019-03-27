using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CefSharp;

namespace CefLibs.CefBrowser
{
    public class LocalFileResourceHandler : ResourceHandler
    {
        private string mimeType;
        private Stream stream;

        public override bool ProcessRequestAsync(IRequest request, ICallback callback)
        {
            Task.Run(() =>
            {
                using (callback)
                {
                    // The 'host' portion is entirely ignored by this scheme handler.
                    var uri = new Uri(request.Url);
                    var fileName = uri.AbsolutePath;

                    var localFilePath = "./_Local/" + fileName;
                    if (File.Exists(localFilePath))
                    {
                        stream = File.OpenRead(localFilePath);

                        var fileExtension = Path.GetExtension(fileName);
                        mimeType = ResourceHandler.GetMimeType(fileExtension);

                        callback.Continue();
                        return true;
                    }

                    callback.Dispose();
                    return false;
                }
            });
            return true;
        }

        public override Stream GetResponse(IResponse response, out long responseLength, out string redirectUrl)
        {
            responseLength = stream.Length;
            redirectUrl = null;

            response.StatusCode = (int)HttpStatusCode.OK;
            response.StatusText = "OK";
            response.MimeType = mimeType;

            return stream;
        }
    }
}