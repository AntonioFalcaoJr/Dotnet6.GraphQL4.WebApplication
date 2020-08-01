using System.Threading;
using System.Threading.Tasks;
using Dotnet5.GraphQL.Store.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet5.GraphQL.Store.Repositories.UnitsOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseFacade _database;
        private readonly DbContext _dbContext;

        public UnitOfWork(StoreContext dbContext)
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