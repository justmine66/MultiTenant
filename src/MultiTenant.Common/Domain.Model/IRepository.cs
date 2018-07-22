using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个资源库接口
    /// </summary>
    /// <remarks>每个聚合跟对应一个资源库。</remarks>
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {

    }
}
