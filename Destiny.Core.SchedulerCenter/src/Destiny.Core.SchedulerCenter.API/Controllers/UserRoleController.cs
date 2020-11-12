using Microsoft.AspNetCore.Mvc;
using Destiny.Core.SchedulerCenter.Application.Identity.UserRole;
using Destiny.Core.SchedulerCenter.AspNetCore.ApiBase;
using Destiny.Core.SchedulerCenter.Dtos.Identity.UserRole;
using Destiny.Core.SchedulerCenter.Shared.Audit;
using Destiny.Core.SchedulerCenter.Shared.OperationResult;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.API.Controllers
{
    [Description("用户角色管理")]
    public class UserRoleController : ApiControllerBase
    {
        private readonly IUserRoleContract _userRoleContract;

        public UserRoleController(IUserRoleContract userRoleContract)
        {
            _userRoleContract = userRoleContract;
        }
        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <returns></returns>
        [Description("用户分配角色")]
        [HttpPost]
        [AuditLog]
        public async Task<AjaxResult> AllocationUserRoleAsync([FromBody] UserRoleInputDto dto)
        {
            return (await _userRoleContract.AllocationRoleAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <returns></returns>
        [Description("获取用户角色")]
        [HttpGet]
        public async Task<AjaxResult> GetLoadUserRoleAsync([FromQuery] Guid? id)
        {
            return (await _userRoleContract.GetLoadUserRoleAsync(id.Value)).ToAjaxResult();
        }
    }
}
