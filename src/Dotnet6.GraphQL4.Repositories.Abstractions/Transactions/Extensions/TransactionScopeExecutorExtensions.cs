using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.Transactions.Extensions
{
    public static class TransactionScopeExecutorExtensions
    {
        public static TransactionScopeExecutor<T> BeginTransactionScope<T>(this Func<T> operation)
            => new(operation);

        public static TransactionScopeExecutor<T> BeginTransactionScope<T>(this Func<CancellationToken, Task<T>> operationAsync)
            => new(operationAsync);
    }
}