using System;
using System.Threading.Tasks;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Destiny.Core.SchedulerCenter.Commands
{
    public class TestCommand : IAsyncCommand<StringPackageInfo>
    {
        public ValueTask ExecuteAsync(IAppSession session, StringPackageInfo package)
        {
            throw new NotImplementedException();
        }
    }
}