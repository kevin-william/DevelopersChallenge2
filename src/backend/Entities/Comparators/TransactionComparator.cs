using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Comparators
{
    public class TransactionComparator : IEqualityComparer<OFXTransaction>
    {
        public bool Equals([AllowNull] OFXTransaction x, [AllowNull] OFXTransaction y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return (x.Value == y.Value && x.DateTime.Equals(y.DateTime) && x.Description.Equals(y.Description));
        }

        public int GetHashCode([DisallowNull] OFXTransaction obj)
        {
            return obj.DateTime.GetHashCode();
        }
    }
}
