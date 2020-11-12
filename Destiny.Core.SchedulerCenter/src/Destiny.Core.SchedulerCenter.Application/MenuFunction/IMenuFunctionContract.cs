using Destiny.Core.SchedulerCenter.Dtos.MenuFunction;
using Destiny.Core.SchedulerCenter.Shared;
using Destiny.Core.SchedulerCenter.Shared.OperationResult;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Application.MenuFunction
{
    public interface IMenuFunctionContract : IScopedDependency
    {
        /// <summary>
        /// 分配菜单功能
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> AllocationMenuFunctionAsync(MenuFunctionInputDto input);
        /// <summary>
        /// 获取菜单功能
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> GetLoadMenuFunctionAsync(Guid id);
    }
}
