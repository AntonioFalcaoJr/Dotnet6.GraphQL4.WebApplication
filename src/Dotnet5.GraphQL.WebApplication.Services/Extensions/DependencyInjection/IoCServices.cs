using AutoMapper;
using Dotnet5.GraphQL.WebApplication.Services.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.WebApplication.Services.Extensions.DependencyInjection
{
    public static class IoCServices
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(ModelToDomainProfile));

        public static IServiceCollection AddServices(this IServiceCollection services)
            => services.AddScoped<IProductService, ProductService>()
               .AddScoped<IReviewService, ReviewService>();
    }
}