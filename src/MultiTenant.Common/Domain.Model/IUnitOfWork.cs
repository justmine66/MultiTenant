using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个工作单元接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 保存所有的变化
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 保存所有的实体
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns></returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
