using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dotnet5.GraphQL3.Store.WebAPI.Graphs.Executers;
using GraphQL;
using GraphQL.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dotnet5.GraphQL3.Store.WebAPI.Graphs.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        private static readonly Options Options = new();

        public static IGraphQLBuilder AddApplicationGraphQL(this IServiceCollection services, Action<Options> actionOptions)
        {
            actionOptions(Options);

            return services
                .AddScoped(typeof(IGraphQLExecuter<>), typeof(StoreGraphQLExecuter<>))
                .AddScoped<IDocumentExecuter, StoreDocumentExecuter>()
                .AddSingleton<StoreSchema>()
                .AddGraphQL(
                    (options, provider) =>
                        {
                            options.EnableMetrics = Options.IsDevelopment;
                            var logger = provider.GetRequiredService<ILogger<Startup>>();
                            options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occured", ctx.OriginalException.Message);
                            options.ComplexityConfiguration = new() {MaxDepth = 15};
                        })
                .AddSystemTextJson(
                    configureSerializerSettings: serializerSettings =>
                        {
                            serializerSettings.WriteIndented = true;
                            serializerSettings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                            serializerSettings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                        })
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