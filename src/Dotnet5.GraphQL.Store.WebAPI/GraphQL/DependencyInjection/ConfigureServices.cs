using System;
using GraphQL.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.DependencyInjection
{
    public static class ConfigureServices
    {
        private static readonly Options Options = new Options();

        public static IGraphQLBuilder AddApplicationGraphQL(this IServiceCollection services, Action<Options> actionOptions)
        {
            actionOptions.Invoke(Options);

            return services.AddSingleton<StoreSchema>()
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Options.IsDevelopment;
                    options.ExposeExceptions = Options.IsDevelopment;
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occured", ctx.OriginalException.Message);
                })
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(StoreSchema));
        }
    }

    public class Options
    {
        public bool IsDevelopment { get; set; }
    }
}