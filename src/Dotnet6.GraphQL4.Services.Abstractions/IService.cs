using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;
using Dotnet6.GraphQL4.Repositories.Abstractions.Pages;
using Dotnet6.GraphQL4.Services.Abstractions.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Dotnet6.GraphQL4.Services.Abstractions
{
    public interface IService<TEntity, in TModel, in TId>
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        bool Delete(TId id);
        bool Delete(TModel model);
        Task<bool> DeleteAsync(TId id, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(TModel model, CancellationToken cancellationToken);

        TEntity Edit(TModel model);
        Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken);

        bool Exists(TId id);
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken);

        PagedResult<TEntity> GetAll(
            PageParams pageParams, 
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, 
            bool asTracking = default);

        PagedResult<TResult> GetAllProjections<TResult>(
            PageParams pageParams, 
            Expression<Func<TEntity, TResult>> selector = default,
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, 
            bool asTracking = default)
            where TResult : class;

        Task<PagedResult<TEntity>> GetAllAsync(
            PageParams pageParams, 
            CancellationToken cancellationToken, 
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, 
            bool asTracking = default);

        Task<PagedResult<TResult>> GetAllProjectionsAsync<TResult>(
            PageParams pageParams, 
            CancellationToken cancellationToken,
            Expression<Func<TEntity, TResult>> selector = default, 
            Expression<Func<TEntity, bool>> predicate = default,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = default,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, 
            bool asTracking = default)
            where TResult : class;

        TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = default, bool asTracking = default);

        TEntity Save(TModel model);
        Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken);
    }
}