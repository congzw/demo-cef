using System;
using System.IO;
using System.Text;

namespace VideoDemo
{
    public class DebugHelper : IDebugHelper
    {
        public string Category { get; set; }

        public void Debug(object message)
        {
            var prefix = "[PTG]";
            if (!string.IsNullOrWhiteSpace(Category))
            {
                prefix = prefix + "[" + Category + "] => ";
            }
            System.Diagnostics.Trace.WriteLine(message, prefix);
        }

        public void Exception(string message)
        {
            Debug(message);

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Exceptions.txt");
            File.AppendAllText(path, $"---- {DateTime.Now} ----", Encoding.UTF8);
            File.AppendAllText(path, Environment.NewLine);
            File.AppendAllText(path, message, Encoding.UTF8);
            File.AppendAllText(path, Environment.NewLine);
        }

        #region for di extensions

        private static IDebugHelper _resolve(string category)
        {
            var debugHelper = new DebugHelper { Category = category ?? "Common" };
            return debugHelper;
        }

        public static Func<string, IDebugHelper> Resolve = _resolve;

        #endregion
    }

    public interface IDebugHelper
    {
        string Category { get; set; }
        void Debug(object message);
        void Exception(string message);
    }
}
