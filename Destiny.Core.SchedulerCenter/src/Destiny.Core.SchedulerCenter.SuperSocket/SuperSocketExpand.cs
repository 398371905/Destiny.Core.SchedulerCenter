using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SuperSocket;
using SuperSocket.ProtoBase;
using System.Collections.Generic;

namespace Destiny.Core.SchedulerCenter.SuperSocket
{
    public static class SuperSocketExpand
    {
        public static ISuperSocketHostBuilder<StringPackageInfo> AddSuperSocketHost(this IHostBuilder hostBuilder)
        {
            //创建SuperSocket主机
            return hostBuilder
               .ConfigureAppConfiguration((hostCtx, configApp) =>
               {
                   //配置Socket服务器的信息,名称和侦听端点并构建主机
                   configApp.AddInMemoryCollection(new Dictionary<string, string>
                   {
                        { "serverOptions:name", "SocketServer" },//服务器名称
                        { "serverOptions:listeners:0:ip", "Any" },//监听者的监听IP；Any：任何ipv4 ip地址
                        { "serverOptions:listeners:0:backLog", "100" },//挂起的连接队列的最大长度；
                        { "serverOptions:listeners:0:port", "4052" }//侦听器的侦听端口
                   });
               })
               .ConfigureLogging((hostCtx, loggingBuilder) =>
               {

               })
               //创建SuperSocket主机
               .AsSuperSocketHostBuilder<StringPackageInfo, CommandLinePipelineFilter>();
        }
    }
}
