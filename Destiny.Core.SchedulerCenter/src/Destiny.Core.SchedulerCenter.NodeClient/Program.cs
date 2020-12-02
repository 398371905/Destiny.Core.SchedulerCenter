using Destiny.Core.SchedulerCenter.NodeApplication.Connect;
using Destiny.Core.SchedulerCenter.NodeApplication.Decoder;
using Destiny.Core.SchedulerCenter.NodeClient.Startups;
using Destiny.Core.SchedulerCenter.Shared.Modules;
using Microsoft.Extensions.DependencyInjection;
using SuperSocket.Client;
using SuperSocket.ProtoBase;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.NodeClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddApplication<SuktAppConsulModule>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var _connect = serviceProvider.GetService<IConnectContract>();
            //初始化管道过滤器
            var pipelineFilter = new CommandLinePipelineFilter
            {
                Decoder = new DefaultStringPackageContract()
            };
            //初始化客户端
            _connect.Client = new EasyClient<StringPackageInfo>(pipelineFilter).AsClient();
            await _connect.ConnectAsync();
            Console.WriteLine("Hello World!");
        }
    }
}
