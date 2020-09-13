using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet5.GraphQL3.Repositories.Abstractions.UnitsOfWork
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

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
            => await _database.BeginTransactionAsync(cancellationToken);

        public void SaveChanges()
            => _dbContext.SaveChanges(true);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _dbContext.SaveChangesAsync(true, cancellationToken);

        public void Commit()
            => _database.CommitTransaction();

        public async Task CommitAsync(CancellationToken cancellationToken = default)
            => await _database.CommitTransactionAsync(cancellationToken);

        public void Rollback()
            => _database.RollbackTransaction();

        public void RollbackToSavepoint(string savePoint)
            => _database.RollbackToSavepoint(savePoint);

        public Task RollbackToSavepointAsync(string savePoint, CancellationToken cancellationToken = default)
            => _database.RollbackToSavepointAsync(savePoint, cancellationToken);

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
            => await _database.RollbackTransactionAsync(cancellationToken);

        public void Dispose()
            => _dbContext?.Dispose();

        public void CreateSavepoint(string savepoint)
            => _database.CreateSavepoint(savepoint);

        public async Task CreateSavepointAsync(string savepoint, CancellationToken cancellationToken = default)
            => await _database.CreateSavepointAsync(savepoint, cancellationToken);
    }
}