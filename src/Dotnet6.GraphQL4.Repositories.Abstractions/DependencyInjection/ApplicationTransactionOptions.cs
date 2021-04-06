using System.Transactions;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection
{
    public class ApplicationTransactionOptions
    {
        public IsolationLevel IsolationLevel { get; set; }
    }
}