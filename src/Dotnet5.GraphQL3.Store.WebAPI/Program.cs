using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.GraphQL3.Store.WebAPI
{
    public static class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .UseDefaultServiceProvider((context, options) =>
                    {
                        options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                        options.ValidateOnBuild = true;
                    });

        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();
    }
}