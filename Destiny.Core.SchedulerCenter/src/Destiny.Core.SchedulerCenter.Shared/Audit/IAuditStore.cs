using MongoDB.Bson;
using Destiny.Core.SchedulerCenter.Shared.Entity;
using Destiny.Core.SchedulerCenter.Shared.Extensions.ResultExtensions;
using Destiny.Core.SchedulerCenter.Shared.OperationResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Shared.Audit
{
    public interface IAuditStore : IScopedDependency
    {
        Task SaveAudit(AuditLog auditLog, List<AuditEntryInputDto> audit);
        Task<IPageResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request);
        Task<OperationResponse> GetAuditEntryListByAuditLogIdAsync(ObjectId id);
        Task<OperationResponse> GetAuditEntryListByAuditEntryIdAsync(ObjectId id);
    }
}