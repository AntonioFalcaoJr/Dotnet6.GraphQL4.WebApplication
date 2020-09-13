using Dotnet5.GraphQL3.CrossCutting.DependencyInjection;
using Dotnet5.GraphQL3.Domain.Abstractions.DependencyInjection;
using Dotnet5.GraphQL3.Repositories.Abstractions.DependencyInjection;
using Dotnet5.GraphQL3.Services.Abstractions.DependencyInjection;
using Dotnet5.GraphQL3.Store.Repositories.Contexts;
using Dotnet5.GraphQL3.Store.Repositories.DependencyInjection;
using Dotnet5.GraphQL3.Store.Services.DependencyInjection;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        public void Configure(IApplicationBuilder app, StoreDbContext dbContext)
        {
            if (_env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting()
                .UseEndpoints(endpoints
                    => endpoints.MapControllers());

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
                .AddServices()
                .AddMessageServices()
                .AddSubjects()
                .AddNotificationContext();

            services.AddApplicationDbContext(options
                => options.ConnectionString = _configuration.GetConnectionString("DefaultConnection"));

            services.AddApplicationGraphQL(options
                => options.IsDevelopment = _env.IsDevelopment());

            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            // If using IIS:
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);
        }
    }
}