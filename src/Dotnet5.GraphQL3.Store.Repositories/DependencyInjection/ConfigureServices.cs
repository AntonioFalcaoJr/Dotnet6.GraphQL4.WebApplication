using System;
using Dotnet5.GraphQL.Store.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.Store.Repositories.DependencyInjection
{
    public static class ConfigureServices
    {
        private const int MaxRetryCount = 5;
        private static readonly TimeSpan MaxRetryDelay = TimeSpan.FromSeconds(5);
        private static readonly RepositoriesOptions Options = new RepositoriesOptions();

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, Action<RepositoriesOptions> options)
        {
            options.Invoke(Options);

            return services
                .AddScoped<DbContext, StoreDbContext>()
                .AddDbContext<StoreDbContext>(DbContextOptionsBuilderAction);
        }

        private static void DbContextOptionsBuilderAction(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString: Options.ConnectionString,
                    sqlServerOptionsAction: SqlServerOptionsAction);

        private static void SqlServerOptionsAction(SqlServerDbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .EnableRetryOnFailure(MaxRetryCount, MaxRetryDelay, null)
                .MigrationsAssembly(typeof(StoreDbContext).Assembly.GetName().Name);
    }

    public class RepositoriesOptions
    {
        public string ConnectionString { get; set; }
    }
}