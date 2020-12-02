using Destiny.Core.SchedulerCenter.Shared;
using SuperSocket.Client;
using SuperSocket.ProtoBase;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.NodeApplication.Connect
{
    public interface IConnectContract : IScopedDependency
    {
        IEasyClient<StringPackageInfo> Client { get; set; }
        Task ConnectAsync();
    }
}
