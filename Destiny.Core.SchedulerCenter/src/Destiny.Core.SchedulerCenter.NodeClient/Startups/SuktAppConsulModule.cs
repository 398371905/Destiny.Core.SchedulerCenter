using Destiny.Core.SchedulerCenter.Shared.Modules;
using Destiny.Core.SchedulerCenter.Shared.SuktDependencyAppModule;

namespace Destiny.Core.SchedulerCenter.NodeClient.Startups
{
    [SuktDependsOn(
         typeof(DependencyAppModule)
         )]
    public class SuktAppConsulModule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {

        }

        public override void ApplicationInitialization(ApplicationContext context)
        {

        }
    }
}
