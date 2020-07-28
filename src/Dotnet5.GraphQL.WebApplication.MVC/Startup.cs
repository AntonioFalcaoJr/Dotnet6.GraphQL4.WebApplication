using Dotnet5.GraphQL.WebApplication.MVC.GraphQL;
using Dotnet5.GraphQL.WebApplication.Repositories.Contexts;
using Dotnet5.GraphQL.WebApplication.Repositories.Extensions.DependencyInjection;
using Dotnet5.GraphQL.WebApplication.Services.Extensions.DependencyInjection;
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

namespace Dotnet5.GraphQL.WebApplication.MVC
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, StoreContext context)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            context.Database.Migrate();

            app.UseGraphQL<StoreSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

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

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }
    }
}