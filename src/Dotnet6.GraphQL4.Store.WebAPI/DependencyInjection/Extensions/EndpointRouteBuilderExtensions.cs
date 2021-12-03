using System;
using System.Linq;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace Dotnet6.GraphQL4.Store.WebAPI.DependencyInjection.Extensions;

public static class EndpointRouteBuilderExtensions
{
    private static readonly string[] ReadinessTags = {"ready"};
    private static readonly string[] LivenessTags = {"live"};
        
    public static void MapLivenessHealthCheck(this IEndpointRouteBuilder endpoints, string pattern)
        => endpoints.MapHealthChecks(
            pattern: pattern,
            predicate: registration 
                => registration.Tags.Any(item 
                    => LivenessTags.Contains(item)));

    public static void MapReadinessHealthCheck(this IEndpointRouteBuilder endpoints, string pattern)
        => endpoints.MapHealthChecks(
            pattern: pattern,
            predicate: registration 
                => registration.Tags.Any(item 
                    => ReadinessTags.Contains(item)));

    public static void MapHealthCheck(this IEndpointRouteBuilder endpoints, string pattern)
        => endpoints.MapHealthChecks(
            pattern: pattern,
            predicate: registration 
                => registration.Tags.Any() is false);

    private static void MapHealthChecks(this IEndpointRouteBuilder endpoints, string pattern, Func<HealthCheckRegistration, bool> predicate = default)
        => endpoints.MapHealthChecks(
            pattern: pattern,
            options: new()
            {
                AllowCachingResponses = false,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                Predicate = predicate,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
            });
        
    public static void MapDumpConfig(this IEndpointRouteBuilder endpoints, string pattern, IConfigurationRoot configurationRoot, bool isProduction, ILogger logger)
    {
        endpoints.MapGet(
            pattern: pattern, 
            requestDelegate: context 
                => isProduction ? DumpToLog(context) : DumpToResponse(context));

        Task DumpToResponse(HttpContext context)
            => context.Response.WriteAsync(
                text: configurationRoot.GetDebugView(), 
                cancellationToken: context.RequestAborted);
            
        Task DumpToLog(HttpContext context)
        {
            logger.LogInformation("{Settings}", configurationRoot.GetDebugView());
                
            return context.Response.WriteAsync(
                text: "Configuration dumped successfully", 
                cancellationToken: context.RequestAborted);
        }
    }
}