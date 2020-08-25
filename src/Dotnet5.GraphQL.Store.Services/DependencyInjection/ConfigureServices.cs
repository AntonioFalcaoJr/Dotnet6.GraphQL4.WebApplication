using AutoMapper;
using Dotnet5.GraphQL.Store.Services.Messages;
using Dotnet5.GraphQL.Store.Services.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.Store.Services.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services
                .AddAutoMapper(
                    typeof(ProductProfile),
                    typeof(ReviewProfile),
                    typeof(ReviewMessageProfile));

        public static IServiceCollection AddServices(this IServiceCollection services)
            => services
                .AddSingleton<IProductService, ProductService>()
                .AddSingleton<IReviewService, ReviewService>();

        public static IServiceCollection AddMessageServices(this IServiceCollection services)
            => services
                .AddSingleton<IReviewMessageService, ReviewMessageService>();
    }
}