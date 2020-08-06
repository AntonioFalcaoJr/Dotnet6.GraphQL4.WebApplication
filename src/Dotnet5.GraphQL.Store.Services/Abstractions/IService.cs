using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Abstractions;

namespace Dotnet5.GraphQL.Store.Services.Abstractions
{
    public interface IService<TEntity, TModel, in TId>
        where TEntity : Entity<TId>
        where TModel : Model<TId>
        where TId : struct
    {
        void Delete(TId id);
        Task DeleteAsync(TId id, CancellationToken cancellationToken = default);

        TEntity Edit(TModel model);
        Task<TEntity> EditAsync(TModel model, CancellationToken cancellationToken = default);

        bool Exists(TId id);
        Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        TEntity GetById(TId id);
        Task<TEntity> GetByIdAsync(TId id, CancellationToken cancellationToken = default);

        TModel Save(TModel model);
        Task<TEntity> SaveAsync(TModel model, CancellationToken cancellationToken = default);
    }
}