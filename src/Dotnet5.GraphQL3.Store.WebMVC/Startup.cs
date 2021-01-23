using System;
using Dotnet5.GraphQL3.Store.WebMVC.Clients;
using Dotnet5.GraphQL3.Store.WebMVC.Extensions.EndpointRouteBuilders;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.GraphQL3.Store.WebMVC
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

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default",
                    "{controller=Home}/{action=Index}/{id?}");
                
                endpoints.MapReadinessHealthChecks();
                endpoints.MapLivenessHealthChecks();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton(_
                => new GraphQLHttpClient(
                    endPoint: new Uri($"{_configuration["HttpClient:Store"]}/graphql"),
                    serializer: new SystemTextJsonSerializer(options =>
                    {
                        options.PropertyNameCaseInsensitive = true;
                        options.IgnoreNullValues = true;
                    })));

            services.AddSingleton<IStoreGraphClient, StoreGraphClient>();

            services.AddHealthChecks()
                .AddUrlGroup(
                    uri: new Uri($"{_configuration["HttpClient:Store"]}/health/ready"), 
                    name: "Store Web API", 
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] {"ready"});
        }
    }
}