using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Core.Data;
using Clean.Core.Data.Specifications;
using Clean.Core.EF.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Clean.Core.EF
{
    public class EfRepository<TDbContext, TEntity> : IAsyncRepository<TEntity> where TDbContext : DbContext where TEntity : class, new()
    {
        private readonly TDbContext _content;

        protected EfRepository(TDbContext content)
        {
            _content = content;
        }

        /// <summary>
        /// Get entity by Id.
        ///
        /// Performs a Find. Which searches locally, because requesting entity from the database. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TEntity> GetByIdAsync(int id)
        {
            return _content.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Gets entity by specifications.
        ///
        /// Once query is built SingleOrDefaultAsync() is called.
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public Task<TEntity> GetBy(IDataSpecification<TEntity> spec)
        {
            IQueryable<TEntity> queryable = _content.Set<TEntity>();
            return EfSpecificationProcessor<TEntity>.BuildQuery(queryable, spec).SingleOrDefaultAsync();
        }

        /// <summary>
        /// List all the items in the database for this entity
        /// </summary>
        /// <returns></returns>
        public Task<List<TEntity>> ListAllAsync()
        {
            return _content.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Filter entity by specification.
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public Task<List<TEntity>> ListAsync(IDataSpecification<TEntity> spec)
        {
            IQueryable<TEntity> queryable = _content.Set<TEntity>();
            return EfSpecificationProcessor<TEntity>.BuildQuery(queryable, spec).ToListAsync();
        }

        /// <summary>
        /// Persist an entity to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> AddAsync(TEntity entity)
        {
            _content.Set<TEntity>().Add(entity);
            return _content.SaveChangesAsync();
        }

        /// <summary>
        /// Persist a collection of entities to the database
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public Task<int> AddAsync(IList<TEntity> entities)
        {
            _content.Set<TEntity>().AddRange(entities);
            return _content.SaveChangesAsync();
        }

        /// <summary>
        /// Update an entity and add it to the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task UpdateAsync(TEntity entity)
        {
            _content.Entry(entity).State = EntityState.Modified;
            return _content.SaveChangesAsync();
        }

        /// <summary>
        /// Update an entity and add it to the database.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public Task UpdateAsync(IList<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _content.Entry(entity).State = EntityState.Modified;
            }
            
            return _content.SaveChangesAsync();
        }

        /// <summary>
        /// Delete and entity from the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task DeleteAsync(TEntity entity)
        {
            _content.Set<TEntity>().Remove(entity);
            return _content.SaveChangesAsync();
        }

        /// <summary>
        /// Get a count from a specification.
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public Task<int> CountAsync(IDataSpecification<TEntity> spec = null)
        {
            IQueryable<TEntity> queryable = _content.Set<TEntity>();
            return EfSpecificationProcessor<TEntity>.BuildQuery(queryable, spec).CountAsync();
        }
    }
}