using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Shared.Audit
{
    public interface IGetChangeTracker : IScopedDependency
    {
        Task<List<AuditEntryInputDto>> GetChangeTrackerList(IEnumerable<EntityEntry> Entries);
    }
}