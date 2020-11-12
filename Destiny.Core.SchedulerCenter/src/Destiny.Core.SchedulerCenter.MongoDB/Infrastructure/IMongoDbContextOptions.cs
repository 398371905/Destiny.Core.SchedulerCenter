namespace Destiny.Core.SchedulerCenter.MongoDB.Infrastructure
{
    public interface IMongoDbContextOptions
    {
        string ConnectionString { get; set; }
    }
}