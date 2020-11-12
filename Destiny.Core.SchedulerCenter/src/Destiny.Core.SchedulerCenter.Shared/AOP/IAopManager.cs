using Microsoft.Extensions.DependencyInjection;

namespace Destiny.Core.SchedulerCenter.Shared.AOP
{
    public interface IAopManager
    {
        /// <summary>
        /// 自动注入AOP
        /// </summary>
        /// <param name="services"></param>
        void AutoLoadAops(IServiceCollection services);
    }
}