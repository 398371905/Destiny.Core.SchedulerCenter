using Destiny.Core.SchedulerCenter.Shared.Events;
using System.Collections.Generic;

namespace Destiny.Core.SchedulerCenter.Shared.Audit
{
    public class AuditEvent : EventBase
    {
        public List<AuditEntryInputDto> AuditList { get; set; }
    }
}