
using Destiny.Core.SchedulerCenter.NodeApplication.MessageDto;
using Destiny.Core.SchedulerCenter.Shared;
using SuperSocket.Client;
using SuperSocket.ProtoBase;

namespace Destiny.Core.SchedulerCenter.NodeApplication.StartProcess
{
    public interface IStartProcessContract : IScopedDependency
    {
        public IEasyClient<StringPackageInfo> Client { get; set; }
        /// <summary>
        /// 启动进程
        /// </summary>
        /// <param name="source"></param>
        void StartTaskFunc(PerformParameter source);
    }
}
