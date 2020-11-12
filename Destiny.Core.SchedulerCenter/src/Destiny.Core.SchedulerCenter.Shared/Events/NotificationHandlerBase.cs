using MediatR;

namespace Destiny.Core.SchedulerCenter.Shared.Events
{
    public abstract class NotificationHandlerBase<TEvent> : EventHandlerBase<TEvent>, INotificationHandler<TEvent> where TEvent : EventBase
    {
    }
}