using System;
using System.Linq.Expressions;

namespace Clean.Common.Specifications.Ordering
{
    public class Descending<T> : IOrderBy<T>
    {
        /// <summary>
        /// Set the property to order by.
        /// </summary>
        public Expression<Func<T, object>> Order { get; set; }

        public OrderDirection Direction { get; } = OrderDirection.Descending;
    }
}