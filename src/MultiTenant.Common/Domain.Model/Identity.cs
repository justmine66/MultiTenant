using System;

namespace MultiTenant.Common.Domain.Model
{
    /// <summary>
    /// 表示一个标识
    /// </summary>
    public abstract class Identity : IIdentity<string>, IEquatable<Identity>
    {
        public Identity()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public Identity(string id)
        {
            Assertion.ArgumentNotNullOrEmpty(nameof(id), id);

            this.Id = id;
        }

        public string Id { get; private set; }
        public bool Equals(Identity id)
        {
            if (ReferenceEquals(null, id)) return false;
            if (ReferenceEquals(this, id)) return true;

            return this.Equals(id);
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Identity);
        }
        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + this.Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"{GetType().Name} [id={Id}]";
        }
    }
}
