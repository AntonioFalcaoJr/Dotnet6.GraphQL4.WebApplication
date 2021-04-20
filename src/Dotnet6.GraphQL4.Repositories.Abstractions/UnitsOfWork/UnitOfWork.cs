using System;
using System.Threading;
using System.Threading.Tasks;
using Dotnet6.GraphQL4.CrossCutting.Notifications;
using Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Options;
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
        private readonly ApplicationTransactionOptions _options;
        private readonly INotificationContext _notificationContext;

        public UnitOfWork(
            DbContext dbContext, 
            IOptionsSnapshot<ApplicationTransactionOptions> optionsMonitor, 
            INotificationContext notificationContext)
        {
            _dbContext = dbContext;
            _options = optionsMonitor.Value;
            _database = _dbContext.Database;
            _notificationContext = notificationContext;
        }

        public TResult ExecuteInTransactionScope<TResult>(Func<TResult> operation, Func<bool> condition)
            => CreateExecutionStrategy().Execute(() => ExecuteInScope(operation, condition));

        public Task<TResult> ExecuteInTransactionScopeAsync<TResult>(Func<CancellationToken, Task<TResult>> operationAsync, Func<CancellationToken, Task<bool>> condition, CancellationToken cancellationToken)
            => CreateExecutionStrategy().ExecuteAsync(ct => ExecuteInScopeAsync(operationAsync, condition, ct), cancellationToken);

        private Task<TResult> ExecuteInScopeAsync<TResult>(Func<CancellationToken, Task<TResult>> operationAsync, Func<CancellationToken, Task<bool>> condition, CancellationToken cancellationToken)
            => operationAsync
                .BeginTransactionScope()
                .WithScopeOption()
                .WithOptions(options => options.IsolationLevel = _options.IsolationLevel)
                .WithScopeAsyncFlowOption()
                .WithConditionAsync(condition ?? (_ => _notificationContext.AllValidAsync))
                .ExecuteAsync(cancellationToken);

        private TResult ExecuteInScope<TResult>(Func<TResult> operation, Func<bool> condition)
            => operation
                .BeginTransactionScope()
                .WithScopeOption()
                .WithOptions(options => options.IsolationLevel = _options.IsolationLevel)
                .WithScopeAsyncFlowOption()
                .WithCondition(condition ?? (() => _notificationContext.AllValid))
                .Execute();

        private IExecutionStrategy CreateExecutionStrategy()
            => _database.CreateExecutionStrategy();

        public bool SaveChanges()
            => _dbContext.SaveChanges(false) > 0;

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(false, cancellationToken) > 0;
    }
}