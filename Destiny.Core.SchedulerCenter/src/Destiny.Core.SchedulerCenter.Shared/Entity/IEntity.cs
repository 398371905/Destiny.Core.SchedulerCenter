using System.ComponentModel;

namespace Destiny.Core.SchedulerCenter.Shared.Entity
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> : IEntity
    {
        [Description("主键")]
        TKey Id { get; }
    }
}