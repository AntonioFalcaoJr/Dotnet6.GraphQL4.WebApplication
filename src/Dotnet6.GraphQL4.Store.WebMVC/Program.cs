using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Dotnet6.GraphQL4.Store.WebMVC
{
    public static class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .UseDefaultServiceProvider(
                    (context, options) =>
                        {
                            options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                            options.ValidateOnBuild = true;
                        });

        public static Task Main(string[] args)
            => CreateHostBuilder(args).Build().RunAsync();
    }
}