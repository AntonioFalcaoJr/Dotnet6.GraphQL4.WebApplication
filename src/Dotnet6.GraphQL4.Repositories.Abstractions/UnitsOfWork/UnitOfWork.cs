using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseFacade _database;
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            _database = _dbContext.Database;
        }

        public IDbContextTransaction BeginTransaction()
            => _database.BeginTransaction();

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
            => _database.BeginTransactionAsync(cancellationToken);

        public bool SaveChanges()
            => _dbContext.SaveChanges(true) > default(int);

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(true, cancellationToken) > default(int);

        public void CommitTransaction()
            => _database.CommitTransaction();

        public Task CommitTransactionAsync(CancellationToken cancellationToken)
            => _database.CommitTransactionAsync(cancellationToken);

        public void RollbackTransaction()
            => _database.RollbackTransaction();

        public Task RollbackTransactionAsync(CancellationToken cancellationToken)
            => _database.RollbackTransactionAsync(cancellationToken);

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}