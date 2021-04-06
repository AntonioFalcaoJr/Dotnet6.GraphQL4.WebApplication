using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Dotnet6.GraphQL4.CrossCutting.Notifications;
using Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection;
using Dotnet6.GraphQL4.Repositories.Abstractions.Transactions.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseFacade _database;
        private readonly DbContext _dbContext;
        private readonly IOptionsMonitor<ApplicationTransactionOptions> _options;
        private readonly INotificationContext _notificationContext;

        public UnitOfWork(DbContext dbContext, IOptionsMonitor<ApplicationTransactionOptions> options, INotificationContext notificationContext)
        {
            _dbContext = dbContext;
            _options = options;
            _database = _dbContext.Database;
            _notificationContext = notificationContext;
        }

        public TResult ExecuteInTransaction<TResult>(Func<TResult> operation, Func<bool> condition)
            => CreateExecutionStrategy().Execute(() => ExecuteWithScope(operation, condition));

        public Task<TResult> ExecuteInTransactionAsync<TResult>(Func<CancellationToken, Task<TResult>> operationAsync, Func<CancellationToken, Task<bool>> condition, CancellationToken cancellationToken)
            => CreateExecutionStrategy().ExecuteAsync(ct => ExecuteWithScopeAsync(operationAsync, condition, ct), cancellationToken);

        private Task<TResult> ExecuteWithScopeAsync<TResult>(Func<CancellationToken, Task<TResult>> operationAsync, Func<CancellationToken, Task<bool>> condition, CancellationToken cancellationToken)
            => operationAsync
                .TransactionAsync()
                .WithScopeOption(TransactionScopeOption.Required)
                .WithOptions(options => options.IsolationLevel = _options.CurrentValue.IsolationLevel)
                .WithScopeAsyncFlowOption(TransactionScopeAsyncFlowOption.Enabled)
                .WithConditionAsync(condition ?? (_ => _notificationContext.AllValidAsync))
                .ExecuteAsync(cancellationToken);

        private TResult ExecuteWithScope<TResult>(Func<TResult> operation, Func<bool> condition)
            => operation
                .Transaction()
                .WithScopeOption(TransactionScopeOption.Required)
                .WithOptions(options => options.IsolationLevel = _options.CurrentValue.IsolationLevel)
                .WithScopeAsyncFlowOption(TransactionScopeAsyncFlowOption.Enabled)
                .WithCondition(condition ?? (() => _notificationContext.AllValid))
                .Execute();

        private IExecutionStrategy CreateExecutionStrategy()
            => _database.CreateExecutionStrategy();

        public bool SaveChanges()
            => _dbContext.SaveChanges(true) > default(int);

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(true, cancellationToken) > default(int);
    }
}