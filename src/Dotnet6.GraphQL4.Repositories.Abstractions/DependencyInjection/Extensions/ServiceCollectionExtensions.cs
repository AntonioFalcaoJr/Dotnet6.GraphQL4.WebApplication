using System.Transactions;
using Dotnet6.GraphQL4.CrossCutting;
using Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Options;
using Dotnet6.GraphQL4.Repositories.Abstractions.UnitsOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Scrutor;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .Scan(selector => selector.FromAssemblies(Application.Assemblies)
                    .AddClasses(filter => filter.AssignableTo(typeof(IRepository<,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static OptionsBuilder<ApplicationTransactionOptions> ConfigureTransactionOptions(this IServiceCollection services, IConfigurationSection section)
            => services
                .AddOptions<ApplicationTransactionOptions>()
                .Bind(section)
                .Validate(options => options.IsolationLevel is not IsolationLevel.Unspecified);
    }
}