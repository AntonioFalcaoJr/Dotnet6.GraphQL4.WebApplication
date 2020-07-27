using Dotnet5.GraphQL.WebApplication.Repositories.Contexts;
using Dotnet5.GraphQL.WebApplication.Repositories.Extensions.DependencyInjection;
using Dotnet5.GraphQL.WebApplication.Services.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.GraphQL.WebApplication.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StoreContext context)
        {
            if (env.IsDevelopment())
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
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddRepositories()
               .AddUnitOfWork();

            services.AddServices()
               .AddAutoMapper();

            services.AddDbContext(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            });
        }
    }
}