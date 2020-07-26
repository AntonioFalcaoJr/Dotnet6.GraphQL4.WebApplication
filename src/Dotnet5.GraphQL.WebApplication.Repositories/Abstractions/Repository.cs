using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.WebApplication.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Abstractions
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual void Delete(TId id)
        {
            var entity = GetById(id);
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual bool Exists(TId id)
            => _dbSet.AsNoTracking().Any(x => Equals(x.Id, id));

        public virtual async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken) =>
            await _dbSet.AsNoTracking().AnyAsync(x => Equals(x.Id, id), cancellationToken);

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
            => predicate is null ? default : _dbSet.Where(predicate);

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
            => predicate is null ? default : await _dbSet.Where(predicate).ToArrayAsync(cancellationToken);

        public virtual TEntity Add(TEntity entity)
        {
            if (Exists(entity.Id)) return entity;
            _dbSet.Add(entity);
            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(entity.Id, cancellationToken)) return entity;
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public virtual TEntity GetById(TId id)
            => Equals(id, default(TId)) ? default : _dbSet.Find(id);

        public virtual async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken)
            => Equals(id, default(TId)) ? default : await _dbSet.FindAsync(new object[] {id}, cancellationToken);

        public void Update(TEntity entity)
        {
            if (Exists(entity.Id) is false) return;
            _dbSet.Update(entity);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(entity.Id, cancellationToken) is false) return;
            _dbSet.Update(entity);
        }
    }
}