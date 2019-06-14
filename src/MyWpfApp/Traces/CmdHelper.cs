using System.Diagnostics;

namespace MyWpfApp.Traces
{
    public class CmdHelper
    {
        public void Kill(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
                break;
            }
        }

        public bool Exist(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        public void Run(string exePath, string args)
        {
            using (var myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = exePath;
                // 此代码意味着程序自行结束，不启用窗口，则需要自己使用Kill关闭进程（例如某些关闭命令行退出的场景）
                myProcess.StartInfo.CreateNoWindow = true;
                if (!string.IsNullOrWhiteSpace(args))
                {
                    myProcess.StartInfo.Arguments = args;
                }
                myProcess.Start();
            }
        }
    }
}
