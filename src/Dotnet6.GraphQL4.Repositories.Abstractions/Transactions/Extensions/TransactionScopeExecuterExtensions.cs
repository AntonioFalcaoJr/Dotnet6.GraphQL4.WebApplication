using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.Transactions.Extensions
{
    public static class TransactionScopeExecuterExtensions
    {
        public static TransactionScopeExecutor<T> Transaction<T>(this Func<T> operation)
            => new(operation);

        public static TransactionScopeExecutor<T> TransactionAsync<T>(this Func<CancellationToken, Task<T>> operationAsync)
            => new(operationAsync);
    }
}