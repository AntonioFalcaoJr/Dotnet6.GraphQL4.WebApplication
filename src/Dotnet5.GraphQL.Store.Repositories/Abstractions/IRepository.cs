using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotnet5.GraphQL.Store.Repositories.Abstractions
{
    public interface IRepository<TEntity, in TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        void Delete(TId id);
        void Delete(TEntity entity);
        Task DeleteAsync(TId id, CancellationToken cancellationToken = default);

        bool Exists(TId id);
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default);

        TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false);

        Task<TEntity> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false, CancellationToken cancellationToken = default);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        IEnumerable<TResult> GetAll<TResult>(
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false);

        Task<IEnumerable<TResult>> GetAllAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false,
            CancellationToken cancellationToken = default);
    }
}