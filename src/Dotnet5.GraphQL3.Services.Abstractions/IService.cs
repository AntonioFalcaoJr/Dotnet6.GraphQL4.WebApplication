using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL3.Domain.Abstractions.Entities;
using Dotnet5.GraphQL3.Services.Abstractions.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotnet5.GraphQL3.Services.Abstractions
{
    public interface IService<TEntity, in TModel, in TId>
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        void Delete(TId id);
        void Delete(TEntity entity);
        Task DeleteAsync(TId id, CancellationToken cancellationToken = default);

        TEntity Edit(TModel model);
        Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken = default);

        bool Exists(TId id);
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default);

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

        TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false);

        Task<TEntity> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default,
            bool withTracking = false, CancellationToken cancellationToken = default);

        TEntity Save(TModel model);
        Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken = default);
    }
}