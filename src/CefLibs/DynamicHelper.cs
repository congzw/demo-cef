using System;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace CefLibs
{
    /// <summary>
    /// 跨类库调用的dynamic帮助类
    /// </summary>
    public class DynamicHelper
    {
        /// <summary>
        /// dynamic as T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="failThrowEx"></param>
        /// <returns></returns>
        public T Convert<T>(dynamic model, bool failThrowEx = false)
        {
            if (model == null)
            {
                return default(T);
            }
            try
            {
                var serializeObject = JsonConvert.SerializeObject(model);
                return JsonConvert.DeserializeObject<T>(serializeObject);
            }
            catch (Exception)
            {
                if (failThrowEx)
                {
                    throw;
                }
                //ignored
                return default(T);
            }
        }

        public string ToJson(dynamic value, bool indented = false)
        {
            return JsonConvert.SerializeObject(value, indented ? Formatting.Indented : Formatting.None);
        }

        public dynamic FromJson(string json)
        {
            return JsonConvert.DeserializeObject(json);
        }

        public bool IsPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
            {
                var dictionary = (IDictionary<string, object>)settings;
                var containsKey = dictionary.ContainsKey(name);
                return containsKey;
            }
            return settings.GetType().GetProperty(name) != null;
        }

        public static DynamicHelper Instance = new DynamicHelper();
    }
}
