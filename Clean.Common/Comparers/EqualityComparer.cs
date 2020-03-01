using System;
using System.Collections.Generic;

namespace Clean.Common.Comparers
{
    public class EqualityComparer<TType> : IEqualityComparer<TType>
    {
        private readonly Func<TType, TType, bool> _comparer;

        public EqualityComparer(Func<TType, TType, bool> comparer)
        {
            _comparer = comparer;
        }

        public bool Equals(TType x, TType y)
        {
            return _comparer(x, y);
        }

        public int GetHashCode(TType obj)
        {
            return obj?.GetHashCode() ?? 0;
        }
    }
}