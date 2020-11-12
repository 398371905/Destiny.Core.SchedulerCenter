using MediatR;
using Destiny.Core.SchedulerCenter.Shared.Extensions;
using Destiny.Core.SchedulerCenter.Shared.Modules;
using Destiny.Core.SchedulerCenter.Shared.SuktReflection;

namespace Destiny.Core.SchedulerCenter.Shared.Events
{
    public class EventBusAppModuleBase : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var assemblys = service.GetOrAddSingletonService<IAssemblyFinder, AssemblyFinder>()?.FindAll();
            service.AddMediatR(assemblys);
            service.AddEvents();
        }
    }
}