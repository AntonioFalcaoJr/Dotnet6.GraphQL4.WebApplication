using System.Reactive.Subjects;
using System.Reflection;
using Dotnet5.GraphQL3.Services.Abstractions.Messages;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet5.GraphQL3.Services.Abstractions.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services.Scan(selector 
                => selector.FromApplicationDependencies(assembly 
                    => assembly.FullName?.StartsWith(GetAssemblySuffix()) ?? default)
                .AddClasses(filter 
                    => filter.AssignableTo(typeof(IService<,,>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        public static IServiceCollection AddMessageServices(this IServiceCollection services)
            => services.Scan(selector 
                => selector.FromApplicationDependencies(assembly 
                    => assembly.FullName?.StartsWith(GetAssemblySuffix()) ?? default)
                .AddClasses(filter 
                    => filter.AssignableTo(typeof(IMessageService<,,>)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

        public static IServiceCollection AddSubjects(this IServiceCollection services)
            => services.AddSingleton(typeof(ISubject<>), typeof(ReplaySubject<>));

        private static string GetAssemblySuffix()
            => Assembly.GetEntryAssembly()?.FullName?.Substring(0, 16);
    }
}