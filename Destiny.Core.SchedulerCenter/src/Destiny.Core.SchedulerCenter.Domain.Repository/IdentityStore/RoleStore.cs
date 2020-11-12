using Destiny.Core.SchedulerCenter.Domain.Models;
using Destiny.Core.SchedulerCenter.Identity;
using Destiny.Core.SchedulerCenter.Shared.Entity;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Repository
{
    public class RoleStore : RoleStoreBase<RoleEntity, Guid, RoleClaimEntity>
    {
        public RoleStore(IEFCoreRepository<RoleEntity, Guid> roleRepository, IEFCoreRepository<RoleClaimEntity, Guid> roleClaimRepository)
            : base(roleRepository, roleClaimRepository)
        { }
    }
}