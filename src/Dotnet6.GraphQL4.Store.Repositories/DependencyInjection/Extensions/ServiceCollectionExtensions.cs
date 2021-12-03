using Dotnet6.GraphQL4.Store.Repositories.Contexts;
using Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    private static readonly string[] ReadinessTags = {"ready"};
    private static readonly string[] LivenessTags = {"live"};
        
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
        => services
            .AddScoped<DbContext, StoreDbContext>()
            .AddDbContext<StoreDbContext>();

    public static OptionsBuilder<SqlServerRetryingOptions> ConfigureSqlServerRetryingOptions(this IServiceCollection services, IConfigurationSection section)
        => services
            .AddOptions<SqlServerRetryingOptions>()
            .Bind(section)
            .ValidateDataAnnotations()
            .ValidateOnStart();

    public static IHealthChecksBuilder AddDbContextHealthChecks(this IServiceCollection services)
        => services.AddHealthChecks()
            .AddDbContextCheck<DbContext>(
                name: "Sql Server (Live)",
                failureStatus: HealthStatus.Degraded,
                tags: LivenessTags)
            .AddDbContextCheck<StoreDbContext>(
                name: "Sql Server (Ready)",
                failureStatus: HealthStatus.Unhealthy,
                tags: ReadinessTags,
                customTestQuery: (dbContext, cancellationToken) 
                    => dbContext.Products.AnyAsync(cancellationToken));
}