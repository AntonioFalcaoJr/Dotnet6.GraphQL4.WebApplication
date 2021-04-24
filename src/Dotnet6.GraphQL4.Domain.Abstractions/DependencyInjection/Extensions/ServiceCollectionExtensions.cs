using Dotnet6.GraphQL4.CrossCutting;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet6.GraphQL4.Domain.Abstractions.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBuilders(this IServiceCollection services)
            => services
                .Scan(selector => selector.FromAssemblies(Application.Assemblies)
                    .AddClasses(filter => filter.AssignableTo(typeof(IBuilder<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
    }
}