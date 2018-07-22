using MultiTenant.Common.Domain.Model;
using MultiTenant.Domain.IdentityModule.TenantAggregate;
using System;

namespace MultiTenant.Domain.IdentityModule.Domain.Events
{
    /// <summary>
    /// 表示一个激活租户的领域事件
    /// </summary>
    public class TenantActivated : IDomainEvent
    {
        public TenantActivated(TenantId tenantId)
        {
            this.EventVersion = 1;
            this.OccurredOn = DateTime.Now;
            this.TenantId = tenantId.Id;
        }

        public int EventVersion { get; set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; private set; }
    }
}
