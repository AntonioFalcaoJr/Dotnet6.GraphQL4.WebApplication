using Dotnet6.GraphQL4.CrossCutting;
using Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Options;
using Dotnet6.GraphQL4.Repositories.Abstractions.UnitsOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Scrutor;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Extensions;

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

    public static OptionsBuilder<TransactionOptions> ConfigureTransactionOptions(this IServiceCollection services, IConfigurationSection section)
        => services
            .AddOptions<TransactionOptions>()
            .Bind(section)
            .ValidateDataAnnotations()
            .Validate(
                validation: options => options.IsolationLevel is not System.Transactions.IsolationLevel.Unspecified,
                failureMessage: "Transaction isolation level must be specified")
            .ValidateOnStart();
}