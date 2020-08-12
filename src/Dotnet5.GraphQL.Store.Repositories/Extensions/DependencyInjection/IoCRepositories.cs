using System;
using Dotnet5.GraphQL.Store.Repositories.Contexts;
using Dotnet5.GraphQL.Store.Repositories.UnitsOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.Store.Repositories.Extensions.DependencyInjection
{
    public static class IoCRepositories
    {
        private static readonly RepositoriesOptions Options = new RepositoriesOptions();

        public static IServiceCollection AddDbContext(this IServiceCollection services, Action<RepositoriesOptions> options)
        {
            options.Invoke(Options);
            return services.AddDbContext<StoreDbContext>(DbContextOptionsBuilderAction);
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IProductRepository, ProductRepository>()
               .AddScoped<IReviewRepository, ReviewRepository>();

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();

        private static void DbContextOptionsBuilderAction(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging()
               .UseSqlServer(Options.ConnectionString, SqlServerOptionsAction);

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