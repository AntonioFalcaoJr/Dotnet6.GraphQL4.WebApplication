using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Domain.Abstractions;

namespace Dotnet5.GraphQL.Store.MVC.Abstractions.Clients
{
    public interface IHttpClient<in TEntity, TClientModel, TId>
        where TClientModel : class //ClientModel<TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<TClientModel> DeleteAsync(CancellationToken cancellationToken = default);
        Task<TClientModel> GetAsync(CancellationToken cancellationToken = default);
        Task<TClientModel> PostAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TClientModel> PutAsync(CancellationToken cancellationToken = default);
    }
}