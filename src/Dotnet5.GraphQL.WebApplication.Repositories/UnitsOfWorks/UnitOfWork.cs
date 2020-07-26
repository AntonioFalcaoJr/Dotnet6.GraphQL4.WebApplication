using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet5.GraphQL.WebApplication.Repositories.UnitsOfWorks
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

        public void SaveChanges()
            => _dbContext.SaveChanges(true);

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(true, cancellationToken);

        public void Commit()
            => _database.CommitTransaction();

        public Task CommitAsync(CancellationToken cancellationToken)
            => _database.CommitTransactionAsync(cancellationToken);

        public void Commit(IDbContextTransaction transaction)
            => transaction.Commit();

        public Task CommitAsync(IDbContextTransaction transaction, CancellationToken cancellationToken)
            => transaction.CommitAsync(cancellationToken);

        public void Rollback()
            => _database.RollbackTransaction();

        public Task RollbackAsync(CancellationToken cancellationToken)
            => _database.RollbackTransactionAsync(cancellationToken);

        public void Rollback(IDbContextTransaction transaction)
            => transaction.Rollback();

        public Task RollbackAsync(IDbContextTransaction transaction, CancellationToken cancellationToken)
            => transaction.RollbackAsync(cancellationToken);

        public void Dispose()
            => _dbContext?.Dispose();
    }
}