using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet5.GraphQL.Store.Repositories.Abstractions.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        void CreateSavepoint(string savepoint);
        Task CreateSavepointAsync(string savepoint, CancellationToken cancellationToken = default);
        void Rollback();
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task RollbackToSavepointAsync(string savePoint, CancellationToken cancellationToken = default);
        void RollbackToSavepoint(string savePoint);
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}