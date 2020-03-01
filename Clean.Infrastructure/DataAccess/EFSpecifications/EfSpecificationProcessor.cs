using System.Linq;
using Clean.Common.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.DataAccess.EFSpecifications
{
    public class EfSpecificationProcessor<TType> : SpecificationProcessor<TType> where TType : class
    {
        public IQueryable<TType> ApplyEFSpecification(IQueryable<TType> query, ISpecification<TType> specification)
        {
            query = AddFilters(query, specification);

            query = AddIncludes(query, specification);

            query = AddOrdering(query, specification);

            query = AddPaging(query, specification);

            return query;
        }

        private static IQueryable<TType> AddPaging(IQueryable<TType> query, ISpecification<TType> specification)
        {
            if (specification is IPaging paging)
            {
                query = query
                    .Skip(paging.Skip)
                    .Take(paging.Take);
            }

            return query;
        }

        private static IQueryable<TType> AddIncludes(IQueryable<TType> query, ISpecification<TType> specification)
        {
            if (specification is IEfSpecification<TType> efSpecification)
            {
                foreach (var t in efSpecification.Includes)
                {
                    query = query.Include(t);
                }
            }

            return query;
        }
    }
}