using Dotnet5.GraphQL.Store.CrossCutting.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.Store.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddNotificationContext(this IServiceCollection services)
            => services.AddScoped<INotificationContext, NotificationContext>();
    }
}