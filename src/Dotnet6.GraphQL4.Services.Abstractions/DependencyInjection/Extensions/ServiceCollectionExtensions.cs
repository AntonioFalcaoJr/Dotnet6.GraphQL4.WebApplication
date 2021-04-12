using System.Reactive.Subjects;
using Dotnet6.GraphQL4.CrossCutting;
using Dotnet6.GraphQL4.Services.Abstractions.Messages;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet6.GraphQL4.Services.Abstractions.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .Scan(selector => selector.FromAssemblies(Application.Assemblies)
                    .AddClasses(filter => filter.AssignableTo(typeof(IService<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        public static IServiceCollection AddApplicationMessageServices(this IServiceCollection services)
            => services
                .Scan(selector => selector.FromAssemblies(Application.Assemblies)
                    .AddClasses(filter => filter.AssignableTo(typeof(IMessageService<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

        public static IServiceCollection AddApplicationAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(Application.Assemblies);

        public static IServiceCollection AddApplicationSubjects(this IServiceCollection services)
            => services.AddSingleton(typeof(ISubject<>), typeof(ReplaySubject<>));
    }
}