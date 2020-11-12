using System;

namespace Destiny.Core.SchedulerCenter.Shared.Security.Jwt
{
    public interface IJwtBearerService : IScopedDependency
    {
        JwtResult CreateToken(Guid userId, string userName);
    }
}