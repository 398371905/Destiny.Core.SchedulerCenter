using Microsoft.EntityFrameworkCore;
using Destiny.Core.SchedulerCenter.Domain.Models;
using Destiny.Core.SchedulerCenter.Dtos.Identity.UserRole;
using Destiny.Core.SchedulerCenter.Shared.Entity;
using Destiny.Core.SchedulerCenter.Shared.Enums;
using Destiny.Core.SchedulerCenter.Shared.Extensions;
using Destiny.Core.SchedulerCenter.Shared.OperationResult;
using Destiny.Core.SchedulerCenter.Shared.ResultMessageConst;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Application.Identity.UserRole
{
    public class UserRoleContract : IUserRoleContract
    {
        private readonly IEFCoreRepository<UserRoleEntity, Guid> _userRoleRepository = null;
        public UserRoleContract(IEFCoreRepository<UserRoleEntity, Guid> userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<OperationResponse> AllocationRoleAsync(UserRoleInputDto dto)
        {
            dto.NotNull(nameof(dto));
            return await _userRoleRepository.UnitOfWork.UseTranAsync(async () =>
            {
                await _userRoleRepository.DeleteBatchAsync(x => x.UserId == dto.Id);
                if (dto.RoleIds?.Any() == true)
                {
                    await _userRoleRepository.InsertAsync(dto.RoleIds.Select(x => new UserRoleEntity
                    {
                        RoleId = x,
                        UserId = dto.Id
                    }).ToArray());
                }
                return new OperationResponse(ResultMessage.AllocationSucces, OperationEnumType.Success);
            });
        }
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<OperationResponse> GetLoadUserRoleAsync(Guid id)
        {
            return new OperationResponse(ResultMessage.LoadSucces, await _userRoleRepository.NoTrackEntities.Where(x => x.UserId == id).Select(x => x.RoleId).ToListAsync(), OperationEnumType.Success);
        }
    }
}
