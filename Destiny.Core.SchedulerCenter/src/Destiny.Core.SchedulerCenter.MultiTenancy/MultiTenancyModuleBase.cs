using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.Shared.Modules;

namespace Destiny.Core.SchedulerCenter.MultiTenancy
{
    public abstract class MultiTenancyModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddScoped<TenantInfo>();
        }
    }
}