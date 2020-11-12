using Destiny.Core.SchedulerCenter.Shared.Permission;
using System.Threading.Tasks;

namespace Destiny.Core.SchedulerCenter.Application.Permission
{
    public class AuthorityVerificationContract : IAuthorityVerification
    {
        public Task<bool> IsPermission(string url)
        {
            //throw new NotImplementedException();
            return Task.FromResult(true);
        }
    }
}