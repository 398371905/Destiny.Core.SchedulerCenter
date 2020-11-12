using Destiny.Core.SchedulerCenter.Dtos.Identity.Role;
using Destiny.Core.SchedulerCenter.Shared;
using Destiny.Core.SchedulerCenter.Shared.Entity;
using Destiny.Core.SchedulerCenter.Shared.Extensions.ResultExtensions;
using Destiny.Core.SchedulerCenter.Shared.OperationResult;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Application.Identity.Role
{
    public interface IRoleContract : IScopedDependency
    {
        /// <summary>
        /// 创建角色及分配权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(RoleInputDto input);

        /// <summary>
        /// 修改角色及分配权限
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(RoleInputDto input);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 分页获取角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPageResult<RoleOutPutPageDto>> GetPageAsync(PageRequest request);
        /// <summary>
        /// 角色分配权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> AllocationRoleMenuAsync(RoleMenuInputDto dto);
    }
}
