using Dotnet5.GraphQL3.CrossCutting.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddNotificationContext(this IServiceCollection services)
            => services.AddScoped<INotificationContext, NotificationContext>();
    }
}