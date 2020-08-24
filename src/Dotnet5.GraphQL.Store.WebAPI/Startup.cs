using Dotnet5.GraphQL.Store.Repositories.Contexts;
using Dotnet5.GraphQL.Store.Repositories.Extensions.DependencyInjection;
using Dotnet5.GraphQL.Store.Services.Extensions.DependencyInjection;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.GraphQL.Store.WebAPI
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
            
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseCors(builder
                => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.UseGraphQL<StoreSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseWebSockets();
            app.UseGraphQLWebSockets<StoreSchema>();

            dbContext.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            
            services.AddRepositories();
            services.AddUnitOfWork();
            services.AddAutoMapper();
            services.AddMessageServices();
            services.AddServices();

            services.AddDbContext(options =>
                options.ConnectionString = _configuration.GetConnectionString("DefaultConnection"));

            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<StoreSchema>();

            services.AddGraphQL(x => x.ExposeExceptions = _env.IsDevelopment())
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(context => context.User)
                .AddDataLoader()
                .AddWebSockets();

            services.AddSingleton<GuidGraphType>();

            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

            // If using IIS:
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);
        }
    }
}