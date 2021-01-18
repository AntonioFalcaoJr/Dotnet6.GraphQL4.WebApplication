using System;
using System.Linq;
using System.Reactive.Subjects;
using System.Reflection;
using AutoMapper;
using Dotnet5.GraphQL3.Services.Abstractions.Messages;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet5.GraphQL3.Services.Abstractions.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services.Scan(selector
                => selector
                    .FromApplicationDependencies(assembly
                        => assembly.FullName?.StartsWith(GetAssemblySuffix()) ?? default)
                    .AddClasses(filter
                        => filter.AssignableToAny(typeof(IService<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        public static IServiceCollection AddMessageServices(this IServiceCollection services)
            => services.Scan(selector
                => selector
                    .FromApplicationDependencies(assembly
                        => assembly.FullName?.StartsWith(GetAssemblySuffix()) ?? default)
                    .AddClasses(filter
                        => filter.AssignableToAny(typeof(IMessageService<,,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());

        public static IServiceCollection AddSubjects(this IServiceCollection services)
            => services.AddSingleton(typeof(ISubject<>), typeof(ReplaySubject<>));

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(
                AppDomain.CurrentDomain.GetAssemblies()
                    .Where(x => x.FullName?
                        .Contains(GetAssemblySuffix()) ?? false));

        private static string GetAssemblySuffix()
            => Assembly.GetEntryAssembly()?.FullName?.Substring(0, 16);
    }
}