namespace Destiny.Core.SchedulerCenter.Shared.Extensions.ResultExtensions
{
    public interface IPageResult<TModel> : IResultBase, IListResult<TModel>
    {
        int Total { get; }
    }
}