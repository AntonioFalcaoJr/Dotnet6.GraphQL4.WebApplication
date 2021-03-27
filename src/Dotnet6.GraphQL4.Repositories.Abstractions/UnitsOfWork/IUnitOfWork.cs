using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        void CommitTransaction();
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        void RollbackTransaction();
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
        bool SaveChanges();
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
    }
}