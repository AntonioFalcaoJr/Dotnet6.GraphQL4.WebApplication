using System.Reactive.Subjects;
using Dotnet5.GraphQL3.CrossCutting.Extensions;
using Dotnet5.GraphQL3.Services.Abstractions.Messages;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet5.GraphQL3.Services.Abstractions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services.Scan(selector
                => selector
                    .FromApplicationDependencies(assembly
                        => assembly.FullName?.StartsWith(assembly.GetEntryAssemblySuffix()) ?? default)
                    .AddClasses(filter
                        => filter.AssignableToAny(typeof(IService<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        public static IServiceCollection AddMessageServices(this IServiceCollection services)
            => services.Scan(selector
                => selector
                    .FromApplicationDependencies(assembly
                        => assembly.FullName?.StartsWith(assembly.GetEntryAssemblySuffix()) ?? default)
                    .AddClasses(filter
                        => filter.AssignableToAny(typeof(IMessageService<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

        public static IServiceCollection AddSubjects(this IServiceCollection services)
            => services.AddSingleton(typeof(ISubject<>), typeof(ReplaySubject<>));
    }
}