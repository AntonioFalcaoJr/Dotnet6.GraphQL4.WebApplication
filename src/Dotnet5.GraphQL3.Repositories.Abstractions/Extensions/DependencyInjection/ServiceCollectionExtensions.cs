using Dotnet5.GraphQL3.CrossCutting;
using Dotnet5.GraphQL3.Repositories.Abstractions.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet5.GraphQL3.Repositories.Abstractions.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(selector => selector.FromAssemblies(Application.Assemblies)
                    .AddClasses(filter => filter.AssignableTo(typeof(IRepository<,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}