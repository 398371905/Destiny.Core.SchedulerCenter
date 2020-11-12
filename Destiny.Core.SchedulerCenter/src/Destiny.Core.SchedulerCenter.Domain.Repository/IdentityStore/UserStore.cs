using Destiny.Core.SchedulerCenter.Domain.Models;
using Destiny.Core.SchedulerCenter.Identity;
using Destiny.Core.SchedulerCenter.Shared.Entity;
using System;

namespace Destiny.Core.SchedulerCenter.Domain.Repository
{
    public class UserStore : UserStoreBase<UserEntity, Guid, UserClaimEntity, UserLoginEntity, UserTokenEntity, RoleEntity, Guid, UserRoleEntity>
    {
        public UserStore(
            IEFCoreRepository<UserEntity, Guid> userRepository,
            IEFCoreRepository<UserLoginEntity, Guid> userLoginRepository,
            IEFCoreRepository<UserClaimEntity, Guid> userClaimRepository,
            IEFCoreRepository<UserTokenEntity, Guid> userTokenRepository,
            IEFCoreRepository<RoleEntity, Guid> roleRepository,
            IEFCoreRepository<UserRoleEntity, Guid> userRoleRepository)
            : base(userRepository, userLoginRepository, userClaimRepository, userTokenRepository, roleRepository, userRoleRepository)
        {
        }
    }
}