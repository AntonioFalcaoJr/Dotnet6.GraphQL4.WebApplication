using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace Dotnet5.GraphQL3.Store.WebMVC.Extensions.EndpointRouteBuilders
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void MapLivenessHealthChecks(this IEndpointRouteBuilder endpoints)
            => endpoints.MapHealthChecks(
                pattern: "/health/live",
                options: new HealthCheckOptions
                {
                    AllowCachingResponses = false,
                    ResponseWriter = WriteHealthCheckLiveResponseAsync,
                    Predicate = registration => registration.Tags.Any() is false
                });

        public static void MapReadinessHealthChecks(this IEndpointRouteBuilder endpoints)
            => endpoints.MapHealthChecks(
                pattern: "/health/ready",
                options: new HealthCheckOptions
                {
                    AllowCachingResponses = false,
                    ResponseWriter = WriteHealthCheckReadyResponseAsync,
                    Predicate = registration => registration.Tags.Contains("ready"),
                    ResultStatusCodes =
                    {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                    }
                });

        private static Task WriteHealthCheckReadyResponseAsync(HttpContext httpContext, HealthReport healthReport)
        {
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(
                JsonConvert.SerializeObject(new
                {
                    OverallStatus = healthReport.Status.ToString(),
                    TotalCheckDuration = healthReport.TotalDuration.TotalSeconds.ToString("00:00:00.000"),
                    DependencyHealthChecks = healthReport.Entries.Select(
                        dependency => new
                        {
                            Name = dependency.Key,
                            Status = dependency.Value.Status.ToString(),
                            Duration = dependency.Value.Duration.TotalSeconds.ToString("00:00:00.000")
                        })
                }));
        }

        private static Task WriteHealthCheckLiveResponseAsync(HttpContext httpContext, HealthReport healthReport)
        {
            httpContext.Response.ContentType = "application/json";
            return httpContext.Response.WriteAsync(
                JsonConvert.SerializeObject(new
                {
                    OverallStatus = healthReport.Status.ToString(),
                    TotalCheckDuration = healthReport.TotalDuration.TotalSeconds.ToString("00:00:00.000")
                }));
        }
    }
}