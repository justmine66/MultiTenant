using System;
using System.Collections.Generic;
using System.Text;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个领域事件接口
    /// </summary>
    public interface IDomainEvent
    {
        /// <summary>
        /// 事件版本号
        /// </summary>
        int EventVersion { get; set; }
        /// <summary>
        /// 发生时间
        /// </summary>
        DateTime OccurredOn { get; set; }
    }
}
