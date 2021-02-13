using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dotnet5.GraphQL3.Domain.Abstractions.Entities;
using Dotnet5.GraphQL3.Repositories.Abstractions.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotnet5.GraphQL3.Repositories.Abstractions
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        private readonly IConfigurationProvider _configuration;
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(DbContext dbDbContext, IConfigurationProvider configuration)
        {
            _configuration = configuration;
            _dbSet = dbDbContext.Set<TEntity>();
        }

        public virtual void Delete(TId id)
        {
            var entity = GetById(id);
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken cancellationToken)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            if (entity is null) return;
            _dbSet.Remove(entity);
        }

        public virtual bool Exists(TId id)
            => _dbSet.Any(x => Equals(x.Id, id));

        public virtual Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken)
            => _dbSet.AnyAsync(x => Equals(x.Id, id), cancellationToken);

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

        public TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            if (Equals(id, default(TId))) return default;
            if (include is null && asTracking) return _dbSet.Find(id);

            return include is null
                ? _dbSet.AsNoTracking().SingleOrDefault(x => Equals(x.Id, id))
                : include(_dbSet).AsNoTracking().SingleOrDefault(x => Equals(x.Id, id));
        }

        public async Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default)
        {
            if (Equals(id, default(TId))) return default;
            if (include is null && asTracking) return await _dbSet.FindAsync(new object[] {id}, cancellationToken);

            return include is null
                ? await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => Equals(x.Id, id), cancellationToken)
                : await include(_dbSet).AsNoTracking().SingleOrDefaultAsync(x => Equals(x.Id, id), cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            if (Exists(entity.Id) is false) return;
            _dbSet.Update(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (await ExistsAsync(entity.Id, cancellationToken) is false) return;
            _dbSet.Update(entity);
        }

        public PagedResult<TEntity> GetAll(
            PageParams pageParams,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default)
        {
            var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTrackingWithIdentityResolution();

            query = include is null ? query : include(query);
            query = predicate is null ? query : query.Where(predicate);
            query = orderBy is null ? query : orderBy(query);

            return PagedResult<TEntity>.Create(query, pageParams);
        }
        
        public PagedResult<TResult> GetAllProjections<TResult>(
            PageParams pageParams,
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default)
        {
            var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTrackingWithIdentityResolution();

            query = include is null ? query : include(query);
            query = predicate is null ? query : query.Where(predicate);
            query = orderBy is null ? query : orderBy(query);

            return selector is null
                ? PagedResult<TResult>.Create(_dbSet.ProjectTo<TResult>(_configuration), pageParams)
                : PagedResult<TResult>.Create(query.Select(selector), pageParams);
        }

        public Task<PagedResult<TEntity>> GetAllAsync(
            PageParams pageParams,
            CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default)
        {
            var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTrackingWithIdentityResolution();

            query = include is null ? query : include(query);
            query = predicate is null ? query : query.Where(predicate);
            query = orderBy is null ? query : orderBy(query);

            return PagedResult<TEntity>.CreateAsync(query, pageParams, cancellationToken);
        }
        
        public Task<PagedResult<TResult>> GetAllProjectionsAsync<TResult>(
            PageParams pageParams,
            CancellationToken cancellationToken,
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool asTracking = default)
        {
            var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTrackingWithIdentityResolution();

            query = include is null ? query : include(query);
            query = predicate is null ? query : query.Where(predicate);
            query = orderBy is null ? query : orderBy(query);

            return selector is null
                ? PagedResult<TResult>.CreateAsync(_dbSet.ProjectTo<TResult>(_configuration), pageParams, cancellationToken)
                : PagedResult<TResult>.CreateAsync(query.Select(selector), pageParams, cancellationToken);
        }
    }
}