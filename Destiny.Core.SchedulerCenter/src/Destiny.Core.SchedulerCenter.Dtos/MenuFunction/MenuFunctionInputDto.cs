using Destiny.Core.SchedulerCenter.Shared.Entity;
using System;
using System.Collections.Generic;

namespace Destiny.Core.SchedulerCenter.Dtos.MenuFunction
{
    /// <summary>
    /// 菜单功能Dto
    /// </summary>
    public class MenuFunctionInputDto : InputDto<Guid>
    {
        /// <summary>
        /// 功能Id
        /// </summary>
        public List<Guid> FuncIds { get; set; }
    }
}
