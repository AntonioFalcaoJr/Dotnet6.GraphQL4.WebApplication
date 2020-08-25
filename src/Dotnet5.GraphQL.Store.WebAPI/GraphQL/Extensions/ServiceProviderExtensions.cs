using System;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static T GetScopedService<T>(this IServiceProvider serviceProvider)
            => serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider
                .GetRequiredService<T>();
    }
}