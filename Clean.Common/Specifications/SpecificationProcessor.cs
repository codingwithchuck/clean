using System.Linq;
using Clean.Common.Specifications.Ordering;

namespace Clean.Common.Specifications
{
    public class SpecificationProcessor<TType>
    {
        /// <summary>
        /// Applies the specification to the IQueryable type. This includes the Filtering and the Ordering.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public IQueryable<TType> BuildQuery(IQueryable<TType> query, ISpecification<TType> specification)
        {
            query = AddFilters(query, specification);
            query = AddOrdering(query, specification);

            return query;
        }

        /// <summary>
        /// Applies the specification to the IQueryable type. This includes the Filtering and the Ordering.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public static IQueryable<TType> ApplySpecification(IQueryable<TType> query, ISpecification<TType> specification)
        {
            var processor = new SpecificationProcessor<TType>();
            return processor.BuildQuery(query, specification);
        }
        
        /// <summary>
        /// Add ordering to IQueryable from specification.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        protected IQueryable<TType> AddOrdering(IQueryable<TType> query, ISpecification<TType> specification)
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
        protected IQueryable<TType> AddFilters(IQueryable<TType> query, ISpecification<TType> specification)
        {
            foreach (var t in specification.Filters)
            {
                query = query.Where(t);
            }

            return query;
        }
    }
}