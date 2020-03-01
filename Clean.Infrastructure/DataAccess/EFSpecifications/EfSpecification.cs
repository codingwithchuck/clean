using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Clean.Common.Specifications;

namespace Clean.Infrastructure.DataAccess.EFSpecifications
{
    public class EfSpecification<TType> : Specification<TType>, IEfSpecification<TType> where TType : class
    {
        public IList<Expression<Func<TType, object>>> Includes { get; } = new List<Expression<Func<TType, object>>>();

        public EfSpecification<TType> Include(Expression<Func<TType, object>> include)
        {
            Includes.Add(include);

            return this;
        }
    }
}