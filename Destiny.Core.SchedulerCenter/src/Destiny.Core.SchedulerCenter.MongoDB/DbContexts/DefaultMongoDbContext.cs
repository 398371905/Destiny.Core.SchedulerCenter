using Destiny.Core.SchedulerCenter.MongoDB.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace Destiny.Core.SchedulerCenter.MongoDB.DbContexts
{
    public class DefaultMongoDbContext : MongoDbContextBase
    {
        public DefaultMongoDbContext([NotNull] MongoDbContextOptions options) : base(options)
        {
        }
    }
}