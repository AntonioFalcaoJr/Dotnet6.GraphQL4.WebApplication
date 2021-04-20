using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.UnitsOfWork
{
    public interface IUnitOfWork
    {
        TResult ExecuteInTransactionScope<TResult>(Func<TResult> operation, Func<bool> condition);
        Task<TResult> ExecuteInTransactionScopeAsync<TResult>(Func<CancellationToken, Task<TResult>> operationAsync, Func<CancellationToken, Task<bool>> condition, CancellationToken cancellationToken);

        bool SaveChanges();
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
}