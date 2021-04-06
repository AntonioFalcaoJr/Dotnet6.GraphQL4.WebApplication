using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Dotnet6.GraphQL4.Store.WebMVC.Extensions.EndpointRouteBuilders
{
    public static class ConfigurationsEndpointRouteBuilderExtensions
    {
        public static void MapDumpConfig(this IEndpointRouteBuilder endpoints, string pattern, string configInfo, bool isDevelopment)
        {
            if (isDevelopment is false) return;
            
            endpoints.MapGet(
                pattern: pattern, 
                requestDelegate: context 
                    => context.Response.WriteAsync(configInfo, context.RequestAborted));
        }
    }
}