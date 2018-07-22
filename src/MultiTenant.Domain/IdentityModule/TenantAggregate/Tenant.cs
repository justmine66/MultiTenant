using MultiTenant.Common.Domain.Model;
using MultiTenant.Domain.IdentityModule.Domain.Events;
using System.Collections.Generic;

namespace MultiTenant.Domain.IdentityModule.TenantAggregate
{
    /// <summary>
    /// 表示一个租户
    /// </summary>
    public class Tenant : EntityWithCompositeId, IAggregateRoot
    {
        #region [ 构造函数 ]

        protected Tenant() { }
        public Tenant(TenantId tenantId, string name, string description = null)
            : this(tenantId, name, description, false)
        { }
        public Tenant(TenantId tenantId, string name, string description, bool active = false)
        {
            Assertion.ArgumentNotNull(nameof(tenantId), tenantId);
            Assertion.ArgumentNotNullOrEmpty(nameof(name), name);
            Assertion.AssertArgumentLength(nameof(name), name, 1, 100);
            Assertion.ArgumentNotNullOrEmpty(nameof(description), description);
            Assertion.AssertArgumentLength(nameof(description), description, 1, 200);

            this.TenantId = tenantId;
            this.Name = name;
            this.Description = description;
            this.Active = active;
        }

        #endregion

        #region [ 公共属性 ]

        /// <summary>
        /// 标识
        /// </summary>
        public TenantId TenantId { get; private set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 存活状态
        /// </summary>
        public bool Active { get; private set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region [ 发布领域事件的业务方法 ]

        /// <summary>
        /// 激活
        /// </summary>
        public void Activate()
        {
            if (!this.Active)
            {
                this.Active = true;
                DomainEventPublisher
                    .Instance
                    .Publish(new TenantActivated(this.TenantId));
            }
        }
        /// <summary>
        /// 禁用
        /// </summary>
        public void Deactivate()
        {
            if (this.Active)
            {
                this.Active = false;

                DomainEventPublisher.Instance.Publish(new TenantDeactivated(this.TenantId));
            }
        }

        #endregion

        #region [ 公共方法 ]

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return this.TenantId;
            yield return this.Name;
        }

        public override string ToString()
        {
            const string Format = "Tenant [tenantId={0}, name={1}, description={2}, active={3}]";
            return string.Format(Format, this.TenantId, this.Name, this.Description, this.Active);
        }

        #endregion
    }
}
