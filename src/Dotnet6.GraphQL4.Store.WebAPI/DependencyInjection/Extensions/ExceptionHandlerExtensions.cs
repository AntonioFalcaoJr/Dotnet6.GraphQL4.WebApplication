using System.Text.Json.Serialization;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Dotnet6.GraphQL4.Store.WebAPI.DependencyInjection.Extensions
{
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseApplicationExceptionHandler(this IApplicationBuilder app)
            => app.UseExceptionHandler(builder 
                => builder.Run(async httpContext =>
                    {
                        var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
                        
                        Log.Error("[Exception Handler] {Error}", exception?.Message);
                        
                        await httpContext.Response.WriteAsJsonAsync(
                            value: new ExecutionResult().AddError(new(exception?.Message)), 
                            options: new() {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull},
                            cancellationToken: httpContext.RequestAborted);
                    }));
    }
}