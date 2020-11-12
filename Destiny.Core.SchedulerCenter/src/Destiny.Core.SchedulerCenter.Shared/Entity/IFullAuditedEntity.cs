namespace Destiny.Core.SchedulerCenter.Shared.Entity
{
    public interface IFullAuditedEntity<TPrimaryKey> : ICreatedAudited<TPrimaryKey>, IModifyAudited<TPrimaryKey>, ISoftDelete where TPrimaryKey : struct
    {
    }
}