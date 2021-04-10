using Dotnet6.GraphQL4.Store.Repositories.Contexts;
using Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
            => services
                .AddScoped<DbContext, StoreDbContext>()
                .AddDbContext<StoreDbContext>();

        public static OptionsBuilder<SqlServerRetryingOptions> ConfigureSqlServerRetryingOptions(this IServiceCollection services, IConfigurationSection section)
            => services
                .AddOptions<SqlServerRetryingOptions>()
                .Bind(section)
                .Validate(
                    validation: options => options.MaxRetryCount <= 10 || options.MaxSecondsRetryDelay <= 10, 
                    failureMessage: "Max value for Retry or Delay must be 10.");
    }
}