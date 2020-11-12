using Destiny.Core.SchedulerCenter.Shared.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.SchedulerCenter.Dtos.Identity.UserRole
{
    /// <summary>
    /// 用户角色管理
    /// </summary>
    public class UserRoleInputDto : InputDto<Guid>
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [DisplayName("角色ID")]
        public List<Guid> RoleIds { get; set; }
    }
}
