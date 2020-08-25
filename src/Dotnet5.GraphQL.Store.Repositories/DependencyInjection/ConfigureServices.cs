using System;
using Dotnet5.GraphQL.Store.Repositories.Contexts;
using Dotnet5.GraphQL.Store.Repositories.UnitsOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.Store.Repositories.DependencyInjection
{
    public static class ConfigureServices
    {
        private static readonly RepositoriesOptions Options = new RepositoriesOptions();

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, Action<RepositoriesOptions> options)
        {
            options.Invoke(Options);
            return services
                .AddDbContext<StoreDbContext>(
                    optionsAction: DbContextOptionsBuilderAction);
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IReviewRepository, ReviewRepository>();

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services
                .AddScoped<IUnitOfWork, UnitOfWork>();

        private static void DbContextOptionsBuilderAction(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString: Options.ConnectionString,
                    sqlServerOptionsAction: SqlServerOptionsAction);

        private static void SqlServerOptionsAction(SqlServerDbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null)
                .MigrationsAssembly(typeof(StoreDbContext).Assembly.GetName().Name);
    }

    public class RepositoriesOptions
    {
        public string ConnectionString { get; set; }
    }
}