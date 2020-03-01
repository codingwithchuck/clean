using System.Collections.Generic;
using System.Threading.Tasks;
using Clean.Common.Specifications;

namespace Clean.Core.DataAccess
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetBy(ISpecification<TEntity> spec);

        Task<List<TEntity>> ListAllAsync();

        Task<List<TEntity>> ListAsync(ISpecification<TEntity> spec);

        Task<int> AddAsync(TEntity entity);

        Task<int> AddAsync(IList<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        Task UpdateAsync(IList<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task<int> CountAsync(ISpecification<TEntity> spec = null);
    }
}