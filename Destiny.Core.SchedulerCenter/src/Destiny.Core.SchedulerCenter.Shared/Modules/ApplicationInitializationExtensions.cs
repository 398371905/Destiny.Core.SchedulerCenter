using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.Shared.SuktDependencyAppModule;

namespace Destiny.Core.SchedulerCenter.Shared.Modules
{
    public static class ApplicationInitializationExtensions
    {
        public static IApplicationBuilder GetApplicationBuilder(this ApplicationContext applicationContext)
        {
            return applicationContext.ServiceProvider.GetRequiredService<IObjectAccessor<IApplicationBuilder>>().Value;
        }
    }
}