using Dotnet6.GraphQL4.CrossCutting.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet6.GraphQL4.CrossCutting.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotificationContext(this IServiceCollection services)
            => services.AddScoped<INotificationContext, NotificationContext>();
    }
}