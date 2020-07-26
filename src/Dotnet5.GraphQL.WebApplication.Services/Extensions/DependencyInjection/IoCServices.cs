using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.WebApplication.Services.Extensions.DependencyInjection
{
    public static class IoCServices
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper();

        public static IServiceCollection AddServices(this IServiceCollection services)
            => services.AddScoped<IProductService, ProductService>();
    }
}