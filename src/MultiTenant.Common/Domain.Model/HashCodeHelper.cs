using System.Collections.Generic;
using System.Linq;

namespace MultiTenant.Common.Domain.Model
{
    public static class HashCodeHelper
    {
        public static int CombineHashCodes(IEnumerable<object> objs)
        {
            Assertion.ArgumentNotNull(nameof(objs), objs);

            unchecked
            {
                var hash = 17;
                hash += objs.Select(x => x == null ? 0 : x.GetHashCode())
                    .Aggregate((x, y) => x ^ y);
                return hash;
            }
        }
    }
}
