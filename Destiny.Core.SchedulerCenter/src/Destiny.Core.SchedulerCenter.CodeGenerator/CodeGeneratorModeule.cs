using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.Shared.Modules;

namespace Destiny.Core.SchedulerCenter.CodeGenerator
{
    public class CodeGeneratorModeule : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddSingleton<ICodeGenerator, RazorCodeGenerator>();
        }
    }
}