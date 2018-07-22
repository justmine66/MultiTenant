namespace MultiTenant.Domain.IdentityModule.TenantAggregate
{
    using MultiTenant.Common.Domain.Model;

    /// <summary>
    /// 表示一个租户标识
    /// </summary>
    public class TenantId : Identity
    {
        public TenantId() { }
        public TenantId(string id) : base(id) { }
    }
}
