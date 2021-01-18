using System;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Executers;
using GraphQL.Server;
using GraphQL.Server.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        private static readonly Options Options = new();

        public static IGraphQLBuilder AddApplicationGraphQL(this IServiceCollection services, Action<Options> actionOptions)
        {
            actionOptions.Invoke(Options);

            return services
                .AddScoped(typeof(IGraphQLExecuter<>), typeof(StoreExecuter<>))
                .AddSingleton<StoreSchema>()
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Options.IsDevelopment;
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