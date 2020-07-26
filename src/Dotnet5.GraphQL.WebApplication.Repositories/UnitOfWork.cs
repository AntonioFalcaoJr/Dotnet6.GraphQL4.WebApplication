using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet5.GraphQL.WebApplication.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private static DbContext _dbContext;
        private readonly DatabaseFacade _database;

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
            => _dbContext.SaveChanges();

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(cancellationToken);

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

        public void RollbackAsync(IDbContextTransaction transaction, CancellationToken cancellationToken)
            => transaction.RollbackAsync(cancellationToken);
    }
}