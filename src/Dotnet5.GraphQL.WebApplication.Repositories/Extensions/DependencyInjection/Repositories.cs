using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.WebApplication.Repositories.Extensions.DependencyInjection
{
    public static class Repositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}