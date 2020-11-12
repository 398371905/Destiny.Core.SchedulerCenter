using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.SchedulerCenter.MongoDB.DbContexts;
using Destiny.Core.SchedulerCenter.MongoDB.Infrastructure;
using System;

namespace Destiny.Core.SchedulerCenter.MongoDB
{
    public static class MongoDBServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbContext<TContext>(this IServiceCollection services, [CanBeNull] Action<MongoDbContextOptions> optionAction) where TContext : MongoDbContextBase
        {
            MongoDbContextOptions options = new MongoDbContextOptions();
            optionAction(options);
            services.AddSingleton<MongoDbContextOptions>(options);
            services.AddScoped<MongoDbContextBase, TContext>();
            return services;
        }
    }
}