using System.Linq;
using Dotnet5.GraphQL3.CrossCutting.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Domain.Abstractions.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Repositories.Abstractions.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Services.Abstractions.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Store.Repositories.Contexts;
using Dotnet5.GraphQL3.Store.Repositories.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Store.WebAPI.Extensions.EndpointRouteBuilders;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.GraphQL3.Store.WebAPI
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

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseApplicationGraphQL<StoreSchema>();
            
            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    
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
            services.AddControllers();

            services
                .AddBuilders()
                .AddRepositories()
                .AddUnitOfWork()
                .AddNotificationContext()
                .AddApplicationServices()
                .AddApplicationMessageServices()
                .AddApplicationSubjects()
                .AddApplicationAutoMapper();
            
            services.AddApplicationDbContext(options =>
                {
                    options.DefaultConnection = _configuration.GetConnectionString(nameof(options.DefaultConnection));
                    _configuration.Bind(nameof(options.ConnectionResiliency), options.ConnectionResiliency);
                });

            services.AddApplicationGraphQL(options
                => options.IsDevelopment = _env.IsDevelopment());

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
                    customTestQuery: async (dbContext, cancellationToken) 
                        => await dbContext.Products.AnyAsync(cancellationToken));
        }
    }
}