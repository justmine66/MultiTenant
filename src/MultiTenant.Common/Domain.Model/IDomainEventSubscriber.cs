using System;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个领域事件订阅者
    /// </summary>
    /// <typeparam name="TDomainEvent">领域事件</typeparam>
    public interface IDomainEventSubscriber<TDomainEvent> 
        where TDomainEvent : IDomainEvent
    {
        /// <summary>
        /// 处理领域事件
        /// </summary>
        /// <param name="domainEvent">领域事件</param>
        void HandleEvent(TDomainEvent domainEvent);
        /// <summary>
        /// 订阅的事件类型
        /// </summary>
        /// <returns></returns>
        Type SubscribedToEventType();
    }
}
