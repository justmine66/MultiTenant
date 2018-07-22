using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个值对象
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// 获取相等组件。
        /// </summary>
        /// <remarks>
        /// 一般情况下，值对象所有属性相等才表示两个值对象相等。
        /// </remarks>
        /// <returns></returns>
        public abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is ValueObject other &&
                this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(this.GetEqualityComponents());
        }
    }
    /// <summary>
    /// 表示一个可克隆的值对象
    /// </summary>
    public abstract class CloneableValueObject : ValueObject, ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
