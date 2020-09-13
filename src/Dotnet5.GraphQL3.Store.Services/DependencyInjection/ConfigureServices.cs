using AutoMapper;
using Dotnet5.GraphQL3.Store.Services.Messages;
using Dotnet5.GraphQL3.Store.Services.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.Store.Services.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services
                .AddAutoMapper(
                    typeof(ProductProfile),
                    typeof(ReviewProfile),
                    typeof(ReviewMessageProfile));

        public static IServiceCollection AddMessageServices(this IServiceCollection services)
            => services
                .AddSingleton<IReviewMessageService, ReviewMessageService>();
    }
}