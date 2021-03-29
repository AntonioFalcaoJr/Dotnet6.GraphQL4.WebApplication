using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Dotnet6.GraphQL4.Store.WebAPI.Extensions.EndpointRouteBuilders
{
    public static class HealthChecksEndpointRouteBuilderExtensions
    {
        private static readonly JsonSerializerOptions SerializerOptions = new() {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true};
        private static readonly HealthCheck HealthCheck = new();
        
        public static void MapApplicationHealthChecks(this IEndpointRouteBuilder endpoints, string pattern, Func<HealthCheckRegistration, bool> predicate = default)
            => endpoints.MapHealthChecks(
                pattern: pattern,
                options: new()
                {
                    AllowCachingResponses = false,
                    ResponseWriter = WriteHealthCheckResponseAsync,
                    Predicate = predicate,
                    ResultStatusCodes =
                    {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                    }
                });

        private static Task WriteHealthCheckResponseAsync(HttpContext httpContext, HealthReport healthReport)
        {
            httpContext.Response.ContentType = "application/json";

            HealthCheck.OverallStatus = healthReport.Status.ToString();
            HealthCheck.TotalCheckDuration = healthReport.TotalDuration.TotalSeconds.ToString("00:00:00.000");
            HealthCheck.DependencyHealthChecks = healthReport.Entries.Any()
                ? healthReport.Entries.Select(dependency 
                    => new DependencyHealthCheck
                        {
                            Name = dependency.Key,
                            Status = dependency.Value.Status.ToString(),
                            Duration = dependency.Value.Duration.TotalSeconds.ToString("00:00:00.000"),
                            Error = dependency.Value.Exception?.Message
                        })
                : default;
            
            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(HealthCheck, SerializerOptions));
        }
    }

    internal class HealthCheck
    {
        public string OverallStatus { get; set; }
        public string TotalCheckDuration { get; set; }
        public IEnumerable<DependencyHealthCheck> DependencyHealthChecks { get; set; }
    }

    internal record DependencyHealthCheck
    {
        public string Name { get; init; }
        public string Status { get; init; }
        public string Duration { get; init; }
        public string Error { get; init; }
    }
}
