using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.GraphQL.Store.WebAPI
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder
                    => webBuilder.UseStartup<Startup>());

        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();
    }
}