using Dotnet5.GraphQL.Store.Repositories.Abstractions.UnitsOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.Store.Repositories.Abstractions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}