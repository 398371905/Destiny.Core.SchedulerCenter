using Destiny.Core.SchedulerCenter.Shared.Permission;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Application.Permissions
{
    public class CheckPermission : IAuthorityVerification
    {
        public Task<bool> IsPermission(string url)
        {
            return Task.FromResult(true);
        }
    }
}
