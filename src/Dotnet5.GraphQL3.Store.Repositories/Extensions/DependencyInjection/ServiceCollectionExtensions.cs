using System;
using Dotnet5.GraphQL3.Store.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.Store.Repositories.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        private static readonly RepositoryOptions Options = new();

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, Action<RepositoryOptions> optionsAction)
        {
            optionsAction(Options);

            return services
                .AddScoped<DbContext, StoreDbContext>()
                .AddDbContext<StoreDbContext>(DbContextOptionsBuilderAction);
        }

        private static void DbContextOptionsBuilderAction(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString: Options.DefaultConnection,
                    sqlServerOptionsAction: SqlServerOptionsAction);

        private static void SqlServerOptionsAction(SqlServerDbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .EnableRetryOnFailure(
                    maxRetryCount: Options.ConnectionResiliency.MaxRetryCount, 
                    maxRetryDelay: Options.ConnectionResiliency.MaxRetryDelay, 
                    errorNumbersToAdd: Options.ConnectionResiliency.ErrorNumbersToAdd)
                .MigrationsAssembly(typeof(StoreDbContext).Assembly.GetName().Name);
    }

    public class ConnectionResiliency
    {
        private const int DefaultMaxRetryCount = 5;
        private const int DefaultMaxRetryDelay = 5;

        private int _maxRetryCount;
        private int _maxSecondsRetryDelay;

        public int MaxRetryCount
        {
            get => _maxRetryCount;
            set => _maxRetryCount = value is default(int) ? DefaultMaxRetryCount : value;
        }

        public int MaxSecondsRetryDelay
        {
            get => _maxSecondsRetryDelay;
            set => _maxSecondsRetryDelay = value is default(int) ? DefaultMaxRetryDelay : value;
        }

        public int[] ErrorNumbersToAdd { get; set; }
        
        internal TimeSpan MaxRetryDelay 
            => TimeSpan.FromSeconds(MaxSecondsRetryDelay);
    }
    
    public class RepositoryOptions
    {
        public string DefaultConnection { get; set; }
        public ConnectionResiliency ConnectionResiliency { get; set; } = new();
    }
}