using Destiny.Core.SchedulerCenter.NodeApplication.MessageDto;
using SuperSocket.Client;
using SuperSocket.ProtoBase;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.NodeApplication.StartProcess
{
    public class StartProcessContract : IStartProcessContract
    {
        public IEasyClient<StringPackageInfo> Client { get; set; }

        public void StartTaskFunc(PerformParameter source)
        {
            try
            {
                Process process = new Process();
                var basePath = Path.GetFullPath(@"..//..//..");
                source.Arguments = Path.Combine(basePath, source.Arguments);
                //启动
                process.StartInfo.FileName = source.FileName;
                process.StartInfo.Arguments = source.Arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(exep_Exited);
                // process.OutputDataReceived += new DataReceivedEventHandler(NetOutputDataHandler);
                // process.EnableRaisingEvents = true;
                //process.ErrorDataReceived += new DataReceivedEventHandler(Process_ErrorDataReceived);
                process.Start();
                source.ProcessId = process.Id;
                Console.WriteLine($"进程ID:{process.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        void exep_Exited(object sender, EventArgs e)
        {
            var poc = sender as Process;
            StreamReader reader = poc.StandardOutput;
            var str = reader.ReadToEnd();
            Task.Run(async () =>
            {
                await Client.SendAsync(Encoding.UTF8.GetBytes($"ReceiveMessage {str}\r\n"));
            });
            Console.WriteLine($"记录信息:{poc.Id},程序退出事件!");
        }
    }
}
