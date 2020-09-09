using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet5.GraphQL.Store.Services.Abstractions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services.Scan(selector
                => selector
                    .FromCallingAssembly()
                    .AddClasses(filter => filter.AssignableToAny(typeof(IService<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
    }
}