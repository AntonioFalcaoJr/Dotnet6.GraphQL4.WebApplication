using System.Linq;
using Dotnet6.GraphQL4.CrossCutting.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Domain.Abstractions.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Store.Repositories.Contexts;
using Dotnet6.GraphQL4.Store.WebAPI.Extensions.EndpointRouteBuilders;
using Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Services.Abstractions.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Store.Repositories.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Store.WebAPI.DependencyInjection.Extensions;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Dotnet6.GraphQL4.Store.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly string[] _readinessTags = {"ready"};
        private readonly string[] _livenessTags = {"live"};

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
            
            app.UseApplicationExceptionHandler();
            
            app.UseSerilogRequestLogging()
                .UseApplicationGraphQL<StoreSchema>()
                .UseRouting()
                .UseEndpoints(
                    endpoints =>
                        {
                            endpoints.MapControllers();

                            endpoints.MapDumpConfig(
                                pattern: "/dump-config",
                                configInfo: (_configuration as IConfigurationRoot).GetDebugView(),
                                isDevelopment: _env.IsDevelopment());

                            endpoints.MapApplicationHealthChecks(
                                pattern: _configuration["HealthChecksPatterns:Health"],
                                predicate: registration 
                                    => registration.Tags.Any() is false);

                            endpoints.MapApplicationHealthChecks(
                                pattern: _configuration["HealthChecksPatterns:Liveness"],
                                predicate: registration 
                                    => registration.Tags.Any(item 
                                        => _livenessTags.Contains(item)));

                            endpoints.MapApplicationHealthChecks(
                                pattern: _configuration["HealthChecksPatterns:Readiness"],
                                predicate: registration 
                                    => registration.Tags.Any(item 
                                        => _readinessTags.Contains(item)));

                            endpoints.MapHealthChecks(
                                pattern: _configuration["HealthChecksPatterns:UI"],
                                options: new() {ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse});
                        });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureTransactionOptions(_configuration.GetSection("Transactions"));
            services.ConfigureSqlServerRetryingOptions(_configuration.GetSection("SqlServerRetryingOptions"));

            services
                .AddLogging()
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

            services.AddApplicationGraphQL();

            services.Configure<KestrelServerOptions>(options
                => options.AllowSynchronousIO = true);

            services.AddHealthChecks()
                .AddDbContextCheck<DbContext>(
                    name: "Sql Server (Live)",
                    failureStatus: HealthStatus.Degraded,
                    tags: _livenessTags)
                .AddDbContextCheck<StoreDbContext>(
                    name: "Sql Server (Ready)",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: _readinessTags,
                    customTestQuery: (dbContext, cancellationToken) 
                        => dbContext.Products.AnyAsync(cancellationToken));
        }
    }
}