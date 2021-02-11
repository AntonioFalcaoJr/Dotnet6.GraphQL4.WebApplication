using System;
using System.Linq;
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
                    uri: new Uri($"{_configuration["HttpClient:Store"]}/health/live"), 
                    name: "Store Web API (Live)", 
                    failureStatus: HealthStatus.Degraded,
                    tags: _livenessTags)
                .AddUrlGroup(
                    uri: new Uri($"{_configuration["HttpClient:Store"]}/health/ready"), 
                    name: "Store Web API (Ready)", 
                    failureStatus: HealthStatus.Unhealthy,
                    tags: _readinessTags);
        }
    }
}