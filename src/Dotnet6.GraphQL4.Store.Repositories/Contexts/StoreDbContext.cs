using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;
using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;
using Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Dotnet6.GraphQL4.Store.Repositories.Contexts
{
    public class StoreDbContext : DbContext
    {
        private const string SqlLatin1GeneralCp1CsAs = "SQL_Latin1_General_CP1_CS_AS";
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;
        private readonly SqlServerRetryingOptions _options;

        public StoreDbContext(
            DbContextOptions options, 
            ILoggerFactory loggerFactory, 
            IConfiguration configuration,
            IOptionsSnapshot<SqlServerRetryingOptions> optionsMonitor)
            : base(options)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
            _options = optionsMonitor.Value;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation(SqlLatin1GeneralCp1CsAs);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    connectionString:_configuration.GetConnectionString("DefaultConnection"), 
                    sqlServerOptionsAction: SqlServerOptionsAction)
                .UseLoggerFactory(_loggerFactory);
        }

        private void SqlServerOptionsAction(SqlServerDbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .ExecutionStrategy(
                    dependencies => new SqlServerRetryingExecutionStrategy(
                        dependencies: dependencies,
                        maxRetryCount: _options.MaxRetryCount,
                        maxRetryDelay: _options.MaxRetryDelay,
                        errorNumbersToAdd: _options.ErrorNumbersToAdd))
                .MigrationsAssembly(assemblyName: typeof(StoreDbContext).Assembly.GetName().Name);
    }
}