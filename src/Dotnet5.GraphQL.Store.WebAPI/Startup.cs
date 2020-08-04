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

        public void Configure(IApplicationBuilder app, StoreContext context)
        {
            if (_env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            context.Database.Migrate();

            app.UseGraphQL<StoreSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRepositories();
            services.AddUnitOfWork();
            services.AddAutoMapper();
            services.AddServices();

            services.AddDbContext(options =>
                options.ConnectionString = _configuration.GetConnectionString("DefaultConnection"));

            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<StoreSchema>();

            services.AddGraphQL(x => x.ExposeExceptions = _env.IsDevelopment())
               .AddGraphTypes(ServiceLifetime.Scoped)
               .AddUserContextBuilder(context => context.User)
               .AddDataLoader();

            services.AddCors();

            services.AddSingleton<GuidGraphType>();

            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
        }
    }
}