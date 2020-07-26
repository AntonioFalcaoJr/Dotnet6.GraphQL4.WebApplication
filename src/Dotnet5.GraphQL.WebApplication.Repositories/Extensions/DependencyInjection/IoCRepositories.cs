using Dotnet5.GraphQL.WebApplication.Repositories.UnitsOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Extensions.DependencyInjection
{
    public static class IoCRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IProductRepository, ProductRepository>();

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}