using System;
using System.Linq.Expressions;

namespace Clean.Common.Specifications.Ordering
{
    public interface IOrderBy<TEntity>
    {
        /// <summary>
        /// Set the property to order by.
        /// </summary>
        Expression<Func<TEntity, object>> Order { get; }

        OrderDirection Direction { get; }
    }
}