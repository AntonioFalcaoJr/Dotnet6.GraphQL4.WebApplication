using Dotnet5.GraphQL3.CrossCutting.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.CrossCutting.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotificationContext(this IServiceCollection services)
            => services.AddScoped<INotificationContext, NotificationContext>();
    }
}