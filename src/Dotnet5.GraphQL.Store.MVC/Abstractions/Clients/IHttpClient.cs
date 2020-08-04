using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Abstractions;

namespace Dotnet5.GraphQL.Store.MVC.Abstractions.Clients
{
    public interface IHttpClient<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<Response<TEntity>> DeleteAsync(CancellationToken cancellationToken = default);
        Task<Response<TEntity>> GetAsync(CancellationToken cancellationToken = default);
        Task<Response<TEntity>> PostAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<Response<TEntity>> PutAsync(CancellationToken cancellationToken = default);
    }
}