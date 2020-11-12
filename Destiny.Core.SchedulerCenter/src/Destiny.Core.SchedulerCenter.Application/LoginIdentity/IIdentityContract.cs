using Destiny.Core.SchedulerCenter.Dtos.LoginIdentity;
using Destiny.Core.SchedulerCenter.Shared;
using Destiny.Core.SchedulerCenter.Shared.OperationResult;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Application.LoginIdentity
{
    public interface IIdentityContract : IScopedDependency
    {
        Task<(OperationResponse item, Claim[] cliams)> Login(LoginInputDto loginDto);
    }
}