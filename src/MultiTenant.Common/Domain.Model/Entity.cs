using System.Collections.Generic;
using System.Linq;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个实体
    /// </summary>
    public abstract class Entity { }
    /// <summary>
    /// 表示一个带有复合身份标识的实体
    /// </summary>
    public abstract class EntityWithCompositeId : Entity
    {
        /// <summary>
        /// 获取身份组件
        /// </summary>
        /// <remarks>
        /// 一般情况下，实体身份标识相等就表示两个实体相等。实现方法一般包含yield return thid.Id代码。
        /// </remarks>
        /// <returns></returns>
        protected abstract IEnumerable<object> GetIdentityComponents();
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is EntityWithCompositeId other &&
                this.GetIdentityComponents().SequenceEqual(other.GetIdentityComponents());
        }
        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(this.GetIdentityComponents());
        }
        public static bool operator ==(EntityWithCompositeId left, EntityWithCompositeId right)
        {
            if (ReferenceEquals(null, left))
                return ReferenceEquals(null, right);
            else
                return left.Equals(right);
        }
        public static bool operator !=(EntityWithCompositeId left, EntityWithCompositeId right)
        {
            return !(left == right);
        }
    }
}
