using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet5.GraphQL.WebApplication.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        void Commit();
        void Commit(IDbContextTransaction transaction);
        Task CommitAsync(CancellationToken cancellationToken);
        Task CommitAsync(IDbContextTransaction transaction, CancellationToken cancellationToken);
        void Rollback();
        void Rollback(IDbContextTransaction transaction);
        Task RollbackAsync(CancellationToken cancellationToken);
        Task RollbackAsync(IDbContextTransaction transaction, CancellationToken cancellationToken);
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}