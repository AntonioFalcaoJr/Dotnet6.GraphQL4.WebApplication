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

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
            => _database.BeginTransactionAsync(cancellationToken);

        public void SaveChanges()
            => _dbContext.SaveChanges(true);

        public Task SaveChangesAsync(CancellationToken cancellationToken)
            => _dbContext.SaveChangesAsync(true, cancellationToken);

        public void Commit()
            => _database.CommitTransaction();

        public Task CommitAsync(CancellationToken cancellationToken)
            => _database.CommitTransactionAsync(cancellationToken);

        public void Rollback()
            => _database.RollbackTransaction();

        public Task RollbackAsync(CancellationToken cancellationToken)
            => _database.RollbackTransactionAsync(cancellationToken);

        public void Dispose()
            => _dbContext?.Dispose();
    }
}