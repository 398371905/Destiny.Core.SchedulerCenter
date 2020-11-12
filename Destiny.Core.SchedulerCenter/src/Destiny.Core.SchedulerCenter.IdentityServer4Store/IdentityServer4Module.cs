using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.IdentityServer4Store.Store;
using Destiny.Core.SchedulerCenter.IdentityServer4Store.Validation;
using Destiny.Core.SchedulerCenter.Shared.Modules;

namespace Destiny.Core.SchedulerCenter.IdentityServerFourStore
{
    public class IdentityServer4Module : SuktAppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var build = service.AddIdentityServer(opt =>
            {
                opt.Events.RaiseErrorEvents = true;
                opt.Events.RaiseInformationEvents = true;
                opt.Events.RaiseFailureEvents = true;
                opt.Events.RaiseSuccessEvents = true;
            }).AddDeveloperSigningCredential().AddProfileService<SuktProfileService>();
            service.AddTransient<IClientStore, ClientStoreBase>();
            service.AddTransient<IResourceStore, ApiResourceStoreBase>();
            service.AddTransient<IPersistedGrantStore, PersistedGrantStoreBase>();
            service.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordBaseValidator>();
            //service.AddTransient<IAccountService, AccountService>();
            //service.AddTransient<IConsentService, ConsentService>();
        }
    }
}
