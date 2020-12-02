using Destiny.Core.SchedulerCenter.NodeApplication.MessageDto;
using Destiny.Core.SchedulerCenter.NodeApplication.StartProcess;
using Destiny.Core.SchedulerCenter.Shared.Extensions;
using SuperSocket.Client;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.NodeApplication.Connect
{
    public class ConnectContract : IConnectContract
    {
        private readonly IStartProcessContract _startProcessContract;

        public ConnectContract(IStartProcessContract startProcessContract)
        {
            _startProcessContract = startProcessContract;
        }

        public IEasyClient<StringPackageInfo> Client { get; set; }

        public async Task ConnectAsync()
        {
            Console.WriteLine("Client start.");
            _startProcessContract.Client = this.Client;
            //接收消息
            Client.PackageHandler += async (s, p) =>
            {
                List<Task> tasks = new List<Task>();
                var bogylist = p.Body.FromJson<List<PerformParameter>>();
                foreach (var item in bogylist)
                {
                    tasks.Add(
                        Task.Run(() =>
                        {
                            _startProcessContract.StartTaskFunc(item);
                        }));
                }
                Task.WhenAll(tasks.ToArray());
                Console.WriteLine($"--------------------{ p.Body}");
                await Task.CompletedTask;
            };
            //客户端连接
            var connected = await Client.ConnectAsync(new IPEndPoint(IPAddress.Parse("10.1.10.172"), 4052));
            if (!connected)
            {
                Console.WriteLine("Failed to connect the target server.");
                return;
            }
            System.Console.WriteLine("Client connect End.");
            //接收
            Client.StartReceive();
            while (true)
            {

            }
        }
    }
}
