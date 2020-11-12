using JetBrains.Annotations;
using Destiny.Core.SchedulerCenter.Shared;

namespace Destiny.Core.SchedulerCenter.MultiTenancy
{
    public interface ISuktConnectionStringResolver : IScopedDependency
    {
        [NotNull]
        string Resolve();
    }
}