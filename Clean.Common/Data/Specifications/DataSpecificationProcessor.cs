using System.Linq;
using Clean.Common.Data.Ordering;

namespace Clean.Common.Data.Specifications
{
    public static class DataSpecificationProcessor<TType> where TType : class
    {
        public static IQueryable<TType> BuildQuery(IQueryable<TType> query, IDataSpecification<TType> specification)
        {
            query = AddFilters(query, specification);
            query = AddOrdering(query, specification);

            return query;
        }
        
        /// <summary>
        /// Add ordering to IQueryable from specification.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        private static IQueryable<TType> AddOrdering(IQueryable<TType> query, IDataSpecification<TType> specification)
        {
            IOrderedQueryable<TType> orderBy = null;

            foreach (var orderBySpecification in specification.Orders)
            {
                if (orderBySpecification.Direction == OrderDirection.Ascending)
                {
                    orderBy = orderBy is null ? query.OrderBy(orderBySpecification.Order) : orderBy.ThenBy(orderBySpecification.Order);
                }

                if (orderBySpecification.Direction == OrderDirection.Descending)
                {
                    orderBy = orderBy is null ? query.OrderByDescending(orderBySpecification.Order) : orderBy.ThenByDescending(orderBySpecification.Order);
                }
            }

            query = orderBy ?? query;
            return query;
        }

        /// <summary>
        /// Add filtering to IQueryable from specification
        /// </summary>
        /// <param name="query"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        private static IQueryable<TType> AddFilters(IQueryable<TType> query, IDataSpecification<TType> specification)
        {
            foreach (var t in specification.Filters)
            {
                query = query.Where(t);
            }

            return query;
        }
    }
}