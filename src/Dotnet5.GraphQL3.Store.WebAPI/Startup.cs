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

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, DbContext dbContext)
        {
            if (_env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapLivenessHealthChecks();
                    endpoints.MapReadinessHealthChecks();
                });

            app.UseApplicationGraphQL<StoreSchema>();

            dbContext.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .AddBuilders()
                .AddRepositories()
                .AddUnitOfWork()
                .AddAutoMapper()
                .AddApplicationServices()
                .AddMessageServices()
                .AddSubjects()
                .AddNotificationContext();

            services.AddApplicationDbContext(options =>
                {
                    options.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
                    _configuration.Bind("DatabaseResilientConnection", options.ResilientConnection);
                });

            services.AddApplicationGraphQL(options
                => options.IsDevelopment = _env.IsDevelopment());

            services.Configure<KestrelServerOptions>(options
                => options.AllowSynchronousIO = true);

            services.AddHealthChecks()
                .AddSqlServer(
                    connectionString: _configuration.GetConnectionString("DefaultConnection"), 
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] {"ready"});
        }
    }
}