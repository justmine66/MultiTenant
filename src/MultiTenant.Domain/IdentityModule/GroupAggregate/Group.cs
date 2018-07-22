using System.Collections.Generic;
using MultiTenant.Common.Domain.Model;

namespace MultiTenant.Domain.IdentityModule.GroupAggregate
{
    /// <summary>
    /// 表示一个群组。
    /// </summary>
    /// <remarks>
    /// 抽象多对多的关系，形成一种群组的概念。比如可以表示一组用户、一组角色等。
    /// </remarks>
    public class Group : EntityWithCompositeId, IAggregateRoot
    {
        protected override IEnumerable<object> GetIdentityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}
