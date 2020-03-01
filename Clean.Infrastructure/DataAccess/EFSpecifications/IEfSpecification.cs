using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Clean.Common.Specifications;

namespace Clean.Infrastructure.DataAccess.EFSpecifications
{
    public interface IEfSpecification<TType> : ISpecification<TType> where TType : class
    {
        IList<Expression<Func<TType, object>>> Includes { get; }
    }
}