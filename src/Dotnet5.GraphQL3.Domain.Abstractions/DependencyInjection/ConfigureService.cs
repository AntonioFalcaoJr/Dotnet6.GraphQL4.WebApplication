using Dotnet5.GraphQL3.Domain.Abstractions.Builders;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet5.GraphQL3.Domain.Abstractions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddBuilders(this IServiceCollection services)
            => services.Scan(selector
                => selector
                    .FromApplicationDependencies()
                    .AddClasses(filter => filter.AssignableToAny(typeof(IBuilder<,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
    }
}