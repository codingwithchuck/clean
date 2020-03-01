using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Clean.Common.Specifications.Ordering;

namespace Clean.Common.Specifications
{
    public class Specification<TType> : ISpecification<TType>
    {
        /// <summary>
        /// The collection of filters for the specification
        /// </summary>
        public IList<Expression<Func<TType, bool>>> Filters { get; } = new List<Expression<Func<TType, bool>>>();

        /// <summary>
        /// The order direction for the specification
        /// </summary>
        public IList<IOrderBy<TType>> Orders { get; } = new List<IOrderBy<TType>>();


        /// <summary>
        /// Set the Where condition.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Specification<TType> Where(Expression<Func<TType, bool>> filter)
        {
            Filters.Add(filter);
            return this;
        }

        /// <summary>
        /// Set additional conditions to the specification.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Specification<TType> And(Expression<Func<TType, bool>> filter)
        {
            return Where(filter);
        }

        /// <summary>
        /// Set the Ascending order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Specification<TType> Ascending(Expression<Func<TType, object>> order)
        {
            Orders.Add(new Ascending<TType>
            {
                Order = order
            });

            return this;
        }

        /// <summary>
        /// Set the Descending order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Specification<TType> Descending(Expression<Func<TType, object>> order)
        {
            Orders.Add(new Descending<TType>
            {
                Order = order
            });

            return this;
        }
    }
}