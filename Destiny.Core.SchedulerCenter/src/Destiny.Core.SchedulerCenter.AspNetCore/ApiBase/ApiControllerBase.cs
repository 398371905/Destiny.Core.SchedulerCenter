using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.SchedulerCenter.AspNetCore.ApiBase
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}