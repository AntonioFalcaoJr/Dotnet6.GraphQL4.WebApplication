using System.Linq;
using Dotnet5.GraphQL3.CrossCutting.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Domain.Abstractions.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Repositories.Abstractions.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Services.Abstractions.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Store.Repositories.Extensions.DependencyInjection;
using Dotnet5.GraphQL3.Store.WebAPI.Extensions.EndpointRouteBuilders;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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
                        pattern: "/health", 
                        predicate: registration
                            => registration.Tags.Any() is false);
                
                    endpoints.MapApplicationHealthChecks(
                        pattern: "/health/live", 
                        predicate: registration
                            => registration.Tags.Any(item 
                                => _livenessTags.Contains(item)));
                    
                    endpoints.MapApplicationHealthChecks(
                        pattern: "/health/ready", 
                        predicate: registration 
                            => registration.Tags.Any(item 
                                => _readinessTags.Contains(item)));
                });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddBuilders()
                .AddRepositories()
                .AddUnitOfWork()
                .AddApplicationServices()
                .AddMessageServices()
                .AddSubjects()
                .AddNotificationContext();
            
            services.AddAutoMapper(typeof(Startup));
            
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
                .AddSqlServer(
                    name:"Sql Server (Live)",
                    connectionString: _configuration.GetConnectionString("DefaultConnection"), 
                    failureStatus: HealthStatus.Degraded,
                    tags: _livenessTags)
                .AddSqlServer(
                    name:"Sql Server (Ready)",
                    connectionString: _configuration.GetConnectionString("DefaultConnection"), 
                    failureStatus: HealthStatus.Unhealthy,
                    tags: _readinessTags);
        }
    }
}