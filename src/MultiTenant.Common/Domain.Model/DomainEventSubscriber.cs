using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个领域事件订阅者
    /// </summary>
    public class DomainEventSubscriber<TDomainEvent> : IDomainEventSubscriber<TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        private readonly Action<TDomainEvent> handle;

        public DomainEventSubscriber(Action<TDomainEvent> handle)
        {
            this.handle = handle;
        }

        public void HandleEvent(TDomainEvent domainEvent)
        {
            this.handle(domainEvent);
        }

        public Type SubscribedToEventType()
        {
            return typeof(TDomainEvent);
        }
    }
}
