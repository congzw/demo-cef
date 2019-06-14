using System;
using System.IO;

namespace MyWpfApp.Traces
{
    public class JaegerHelper
    {
        public CmdHelper CmdHelper { set; get; }

        public JaegerHelper(CmdHelper cmdHelper)
        {
            CmdHelper = cmdHelper;
        }

        private string jaegerProcessName = "jaeger-all-in-one";
        private string args = "--collector.zipkin.http-port=9411";
        public bool LocalExeExist()
        {
            var jaegerExePath = AppDomain.CurrentDomain.BaseDirectory + jaegerProcessName + ".exe";
            return File.Exists(jaegerExePath);
        }

        public void Start()
        {
            var jaegerProcessExist = CmdHelper.Exist(jaegerProcessName);
            if (jaegerProcessExist)
            {
                Console.WriteLine("jaeger already running!");
                return;
            }

            //jaeger-all-in-one --collector.zipkin.http-port=9411
            var jaegerPath = AppDomain.CurrentDomain.BaseDirectory + jaegerProcessName;
            CmdHelper.Run(jaegerPath, args);
            Console.WriteLine("start jaeger!");
        }
        public void Stop()
        {
            var jaegerProcessExist = CmdHelper.Exist(jaegerProcessName);
            if (!jaegerProcessExist)
            {
                Console.WriteLine("jaeger not running!");
                return;
            }
            CmdHelper.Kill(jaegerProcessName);
            Console.WriteLine("stop jaeger!");
        }
    }
}