using CefLibs;
using CefLibs.CefBrowser;

namespace CallbackDemo.ViewModel
{
    public class MainWindowJs
    {
        public CefViewHelper MainCefViewHelper { get; set; }

        public void FooWithCallback(dynamic config, dynamic successCallback, dynamic failCallback)
        {
            var dynamicHelper = DynamicHelper.Instance;
            var json = dynamicHelper.ToJson(config);
            MainCefViewHelper.Debug(json);
            var json2 = dynamicHelper.ToJson(successCallback);
            MainCefViewHelper.Debug(json2);
            var json3 = dynamicHelper.ToJson(failCallback);
            MainCefViewHelper.Debug(json3);

            if (dynamicHelper.IsPropertyExist(config, "ShouldSuccess"))
            {
                var shouldSuccess = config.ShouldSuccess != null && config.ShouldSuccess;
                if (shouldSuccess)
                {
                    MainCefViewHelper.ExecuteCallbackAsync(successCallback, new { Success = true, Message = "completed with success!", Data = (object)null });
                    return;
                }
            }
            MainCefViewHelper.ExecuteCallbackAsync(failCallback, new { Success = false, Message = "completed with failed!", Data = (object)null });
        }
    }
}
