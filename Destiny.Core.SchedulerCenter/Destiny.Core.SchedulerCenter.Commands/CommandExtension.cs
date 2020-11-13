using System.Reflection;
using SuperSocket;
using SuperSocket.Command;
using SuperSocket.ProtoBase;

namespace Destiny.Core.SchedulerCenter.Commands
{
    public static class CommandExtension
    {
        public static ISuperSocketHostBuilder ConfigureCommands(this ISuperSocketHostBuilder<StringPackageInfo>  builder)
        {
            return builder.UseCommand(options =>
            options.AddCommandAssembly(typeof(CommandExtension).GetTypeInfo().Assembly));
        }
    }
}