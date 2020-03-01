using System;
using System.Linq.Expressions;

namespace Clean.Common.Data.Specifications.Ordering          
{
    public class Ascending<T> : IOrderBy<T> where T : class
    {
        /// <summary>
        /// Set the property to order by.
        /// </summary>
        public Expression<Func<T, object>> Order { get; set; }

        public OrderDirection Direction { get; } = OrderDirection.Ascending;
    }
}