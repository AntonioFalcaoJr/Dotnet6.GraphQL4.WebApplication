using System.Transactions;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Options
{
    public class ApplicationTransactionOptions
    {
        public IsolationLevel IsolationLevel { get; set; }
    }
}