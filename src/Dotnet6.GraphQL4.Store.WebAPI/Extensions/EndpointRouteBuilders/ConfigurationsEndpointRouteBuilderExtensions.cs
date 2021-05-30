using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace Dotnet6.GraphQL4.Store.WebAPI.Extensions.EndpointRouteBuilders
{
    public static class ConfigurationsEndpointRouteBuilderExtensions
    {
        public static void MapDumpConfig(this IEndpointRouteBuilder endpoints, string pattern, IConfigurationRoot configurationRoot, bool isProduction)
        {
            if (isProduction) return;

            endpoints.MapGet(
                pattern: pattern,
                requestDelegate: context 
                    => context.Response.WriteAsync(
                        text: configurationRoot.GetDebugView(), 
                        cancellationToken: context.RequestAborted));
        }
    }
}