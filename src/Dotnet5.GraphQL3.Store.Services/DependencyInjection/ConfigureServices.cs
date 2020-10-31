using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.Store.Services.DependencyInjection
{
public static class ConfigureServices
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        => services.AddAutoMapper(
            AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName?
                    .Contains(GetAssemblySuffix()) ?? false));

    private static string GetAssemblySuffix()
        => Assembly.GetEntryAssembly()?.FullName?.Substring(0, 11);
}
}