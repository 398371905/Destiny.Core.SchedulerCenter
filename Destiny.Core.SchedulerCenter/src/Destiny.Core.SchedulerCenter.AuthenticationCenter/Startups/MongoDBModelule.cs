using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.MongoDB;
using Destiny.Core.SchedulerCenter.MongoDB.DbContexts;
using Destiny.Core.SchedulerCenter.Shared.Extensions;

namespace Destiny.Core.SchedulerCenter.AuthenticationCenter.Startups
{
    public class MongoDBModelule : MongoDBModuleBase
    {
        protected override void AddDbContext(IServiceCollection services)
        {
            var connection = services.GetConfiguration()["SuktCore:DbContext:MongoDBConnectionString"];
            services.AddMongoDbContext<DefaultMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });
        }
    }
}
