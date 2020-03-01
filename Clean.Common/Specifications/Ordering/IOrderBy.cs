using System;
using System.Linq.Expressions;

namespace Clean.Common.Data.Specifications.Ordering
{
    public interface IOrderBy<TEntity> where TEntity : class
    {
        /// <summary>
        /// Set the property to order by.
        /// </summary>
        Expression<Func<TEntity, object>> Order { get; }

        OrderDirection Direction { get; }
    }
}