using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Application.Socket
{
    public class ReceiveMessage : IAsyncCommand<IAppSession, StringPackageInfo>
    {
        public async ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            await Task.CompletedTask;
            System.Console.WriteLine($"客户端发送消息{package.Body}");
        }
    }
}
