using Microsoft.Extensions.Options;
using SuperSocket;
using SuperSocket.Channel;
using SuperSocket.Server;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Application.Socket
{
    public class DestinyCoreSuperSocketService<TReceivePackageInfo> : SuperSocketService<TReceivePackageInfo> where TReceivePackageInfo : class
    {
        private readonly IServiceProvider _serviceProvider;
        public DestinyCoreSuperSocketService(IServiceProvider serviceProvider, IOptions<ServerOptions> serverOptions) : base(serviceProvider, serverOptions)
        {
            _serviceProvider = serviceProvider;
        }

        //连接开启后
        protected override ValueTask OnSessionConnectedAsync(IAppSession session)
        {
            Console.WriteLine($"客户端:{session.LocalEndPoint}连接开启");
            var sessionConnected = base.OnSessionConnectedAsync(session);
            return sessionConnected;
        }

        //关闭连接后
        protected override ValueTask OnSessionClosedAsync(IAppSession session, CloseEventArgs e)
        {
            Console.WriteLine($"客户端:{session.LocalEndPoint}连接关闭");
            var sessionClosed = base.OnSessionClosedAsync(session, e);
            return sessionClosed;
        }
        //服务启动后
        protected override ValueTask OnStartedAsync()
        {
            Console.WriteLine($"服务启动");
            return base.OnStartedAsync();
        }

        //服务停止后
        protected override ValueTask OnStopAsync()
        {
            Console.WriteLine($"服务停止");
            return base.OnStopAsync();
        }

        //新的客户端
        protected override void OnNewClientAccept(IChannelCreator listener, IChannel channel)
        {
            Console.WriteLine($"新的客户端:{channel.LocalEndPoint}连接开启");
            base.OnNewClientAccept(listener, channel);
        }
    }
}
