using Dotnet5.GraphQL.Store.Domain.Abstractions.Builders;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet5.GraphQL.Store.Domain.Abstractions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddBuilders(this IServiceCollection services)
        {
            return services.Scan(selector
                => selector
                    .FromCallingAssembly()
                    .AddClasses(filter => filter.AssignableToAny(typeof(IBuilder<,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        }
    }
}