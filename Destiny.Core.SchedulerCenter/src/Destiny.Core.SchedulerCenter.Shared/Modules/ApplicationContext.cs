using Destiny.Core.SchedulerCenter.Shared.Extensions;
using Destiny.Core.SchedulerCenter.Shared.SuktDependencyAppModule;
using System;

namespace Destiny.Core.SchedulerCenter.Shared.Modules
{
    /// <summary>
    /// 自定义应用上下文
    /// </summary>
    public class ApplicationContext : IServiceProviderAccessor
    {
        public ApplicationContext(IServiceProvider serviceProvider)
        {
            serviceProvider.NotNull(nameof(serviceProvider));
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; set; }
    }
}