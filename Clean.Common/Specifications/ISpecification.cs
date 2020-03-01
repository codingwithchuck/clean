using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Clean.Common.Specifications.Ordering;

namespace Clean.Common.Specifications
{
    public interface ISpecification<T>
    {
        /// <summary>
        /// The collection of filters for the specification.
        /// </summary>
        IList<Expression<Func<T, bool>>> Filters { get; }

        /// <summary>
        /// The order direction for the specification.
        /// </summary>
        IList<IOrderBy<T>> Orders { get; }
    }
}