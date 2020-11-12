using MongoDB.Bson;
using Destiny.Core.SchedulerCenter.Shared.Entity;

namespace Destiny.Core.SchedulerCenter.MongoDB
{
    public abstract class MongoEntity : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}