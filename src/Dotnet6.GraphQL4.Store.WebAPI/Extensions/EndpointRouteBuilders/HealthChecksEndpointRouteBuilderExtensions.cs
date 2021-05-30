using System;
using System.Linq;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Dotnet6.GraphQL4.Store.WebAPI.Extensions.EndpointRouteBuilders
{
    public static class HealthChecksEndpointRouteBuilderExtensions
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
    }
}
