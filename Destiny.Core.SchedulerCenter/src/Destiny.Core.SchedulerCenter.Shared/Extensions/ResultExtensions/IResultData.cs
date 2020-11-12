using System.Collections.Generic;

namespace Destiny.Core.SchedulerCenter.Shared.Extensions.ResultExtensions
{
    public interface IResultData<TData>
    {
        IEnumerable<TData> Data { get; set; }
    }
}