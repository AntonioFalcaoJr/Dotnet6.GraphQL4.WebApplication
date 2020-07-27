using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet5.GraphQL.WebApplication.Repositories.UnitsOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken);
        void CreateSavepoint(string savepoint);
        Task CreateSavepointAsync(string savepoint, CancellationToken cancellationToken);
        void Rollback();
        Task RollbackAsync(CancellationToken cancellationToken);
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}