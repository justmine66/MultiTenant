using System;
using System.Collections.Generic;
using System.Threading;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 领域事件发布器
    /// </summary>
    public class DomainEventPublisher
    {
        #region [ 私有字段和属性 ]

        [ThreadStatic]
        private static DomainEventPublisher _instance;

        private List<IDomainEventSubscriber<IDomainEvent>> _subscribers;

        private bool publishing;

        #endregion

        #region [ 公共属性 ]

        /// <summary>
        /// 线程单例
        /// </summary>
        public static DomainEventPublisher Instance
        {
            get
            {
                Interlocked.CompareExchange<DomainEventPublisher>(
                    ref _instance,
                    new DomainEventPublisher(),
                    null);
                return _instance;
            }
        }
        /// <summary>
        /// 事件订阅器者列表
        /// </summary>
        List<IDomainEventSubscriber<IDomainEvent>> Subscribers
        {
            get
            {
                Interlocked.CompareExchange<List<IDomainEventSubscriber<IDomainEvent>>>(
                    ref _subscribers,
                    new List<IDomainEventSubscriber<IDomainEvent>>(),
                    null);
                return _subscribers;
            }
            set
            {
                _subscribers = value;
            }
        }

        #endregion

        #region [ 公共方法 ]

        /// <summary>
        /// 发布领域事件
        /// </summary>
        /// <typeparam name="TDomainEvent">具体的领域事件</typeparam>
        /// <param name="domainEvent">领域事件</param>
        public void Publish<TDomainEvent>(TDomainEvent @event)
            where TDomainEvent : IDomainEvent
        {
            Assertion.ArgumentNotNull(nameof(@event), @event);

            if (!this.publishing && this.HasSubscribers())
            {
                try
                {
                    this.publishing = true;

                    var eventType = @event.GetType();
                    foreach (var subscriber in this.Subscribers)
                    {
                        if (subscriber.SubscribedToEventType() == eventType)
                        {
                            subscriber.HandleEvent(@event);
                        }
                    }
                }
                finally
                {
                    this.publishing = false;
                }
            }
        }
        /// <summary>
        /// 发布集合中所有的领域事件
        /// </summary>
        /// <param name="domainEvents"></param>
        public void PublishAll(ICollection<IDomainEvent> domainEvents)
        {
            Assertion.ArgumentNotNull(nameof(domainEvents), domainEvents);

            foreach (var domainEvent in domainEvents)
            {
                this.Publish(domainEvent);
            }
        }
        /// <summary>
        /// 订阅领域事件
        /// </summary>
        /// <param name="subscriber"></param>
        public void Subscribe(IDomainEventSubscriber<IDomainEvent> subscriber)
        {
            if (!this.publishing)
            {
                this.Subscribers.Add(subscriber);
            }
        }
        public void Subscribe(Action<IDomainEvent> handle)
        {
            Subscribe(new DomainEventSubscriber<IDomainEvent>(handle));
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <remarks>
        /// 清空订阅者列表
        /// </remarks>
        public void Reset()
        {
            if (!this.publishing)
            {
                this.Subscribers = null;
            }
        }

        #endregion

        #region [ 私有方法 ]

        private bool HasSubscribers()
        {
            return this._subscribers != null && this.Subscribers.Count != 0;
        }

        #endregion
    }
}
