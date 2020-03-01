using System.Collections.Generic;
using System.Linq;

namespace Clean.Common.Specifications
{
    public static class SpecificationExtensions
    {
        /// <summary>
        /// Applies the specification to the items collection and returns a IQueryable.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="specification"></param>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        public static IQueryable<TType> ApplySpecification<TType>(
            this IEnumerable<TType> items, 
            ISpecification<TType> specification
        ) 
            => SpecificationProcessor<TType>.ApplySpecification(items.AsQueryable(), specification);
    }
}