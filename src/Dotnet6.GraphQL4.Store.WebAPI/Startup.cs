using Dotnet6.GraphQL4.CrossCutting.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Domain.Abstractions.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Store.WebAPI.Extensions.EndpointRouteBuilders;
using Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Options;
using Dotnet6.GraphQL4.Services.Abstractions.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Options;
using Dotnet6.GraphQL4.Store.WebAPI.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Dotnet6.GraphQL4.Store.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app , ILoggerFactory loggerFactory)
        {
            if (_env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            loggerFactory.AddSerilog();

            app.UseHttpLogging()
                .UseApplicationExceptionHandler()
                .UseSerilogRequestLogging()
                .UseApplicationGraphQL<StoreSchema>()
                .UseRouting()
                .UseEndpoints(
                    endpoints =>
                        {
                            endpoints.MapControllers();

                            endpoints.MapDumpConfig(
                                pattern: "/dump-config",
                                configurationRoot: _configuration as IConfigurationRoot,
                                isProduction: _env.IsProduction());

                            endpoints.MapHealthCheck(
                                pattern: _configuration["HealthChecksPatterns:Health"]);

                            endpoints.MapLivenessHealthCheck(
                                pattern: _configuration["HealthChecksPatterns:Liveness"]);

                            endpoints.MapReadinessHealthCheck(
                                pattern: _configuration["HealthChecksPatterns:Readiness"]);
                        });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureTransactionOptions(
                section: _configuration.GetSection(nameof(TransactionOptions)));
            
            services.ConfigureSqlServerRetryingOptions(
                section: _configuration.GetSection(nameof(SqlServerRetryingOptions)));

            services.AddHttpLogging(options 
                => options.LoggingFields = HttpLoggingFields.RequestProperties);

            services.AddLogging()
                .AddBuilders()
                .AddRepositories()
                .AddUnitOfWork()
                .AddNotificationContext()
                .AddApplicationServices()
                .AddApplicationMessageServices()
                .AddApplicationSubjects()
                .AddApplicationAutoMapper()
                .AddApplicationDbContext()
                .AddControllers();

            services.AddDbContextHealthChecks();
            services.AddApplicationGraphQL();

            services.Configure<KestrelServerOptions>(options
                => options.AllowSynchronousIO = true);
        }
    }
}