using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.AutoMapper;
using Destiny.Core.SchedulerCenter.Domain.Models;
using Destiny.Core.SchedulerCenter.IdentityServerFourStore;
using Destiny.Core.SchedulerCenter.Shared.AppOption;
using Destiny.Core.SchedulerCenter.Shared.Events;
using Destiny.Core.SchedulerCenter.Shared.Extensions;
using Destiny.Core.SchedulerCenter.Shared.Modules;
using Destiny.Core.SchedulerCenter.Shared.SuktDependencyAppModule;
using System;
using System.Linq;

namespace Destiny.Core.SchedulerCenter.AuthenticationCenter.Startups
{
    [SuktDependsOn(
        typeof(IdentityModule),
        typeof(DependencyAppModule),
        typeof(EventBusAppModuleBase),
        typeof(EntityFrameworkCoreMySqlModule),
        typeof(SuktAutoMapperModuleBase),
        typeof(IdentityServer4Module),
        typeof(MigrationModuleBase)
    )]
    public class SuktAppWebModule : SuktAppModule
    {
        private string _corePolicyName = string.Empty;
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            if (!_corePolicyName.IsNullOrEmpty())
            {
                app.UseCors(_corePolicyName); //添加跨域中间件
            }
            app.UseStaticFiles();
            app.UseRouting();
            if (!_corePolicyName.IsNullOrEmpty())
            {
                app.UseCors(_corePolicyName); //添加跨域中间件
            }
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            service.AddMvc();
            var configuration = service.GetConfiguration();
            service.Configure<AppOptionSettings>(configuration.GetSection("SuktCore"));
            var settings = service.GetAppSettings();
            if (!settings.Cors.PolicyName.IsNullOrEmpty() && !settings.Cors.Url.IsNullOrEmpty()) //添加跨域
            {
                _corePolicyName = settings.Cors.PolicyName;
                service.AddCors(c =>
                {
                    c.AddPolicy(settings.Cors.PolicyName, policy =>
                    {
                        policy.WithOrigins(settings.Cors.Url
                          .Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray())
                        //policy.WithOrigins("http://localhost:5001")//支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                        .AllowAnyHeader().AllowAnyMethod().AllowCredentials();//允许cookie;
                    });
                });
            }
            //context.Services.AddTransient<IPrincipal>(provider =>
            //{
            //    IHttpContextAccessor accessor = provider.GetService<IHttpContextAccessor>();
            //    return accessor?.HttpContext?.User;
            //});
        }
    }
}
