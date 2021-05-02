using System.Transactions;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Options
{
    public class TransactionOptions
    {
        private const IsolationLevel DefaultIsolationLevel = IsolationLevel.ReadCommitted;
        private IsolationLevel? _isolationLevel;

        public IsolationLevel IsolationLevel
        {
            get => _isolationLevel ?? DefaultIsolationLevel;
            set => _isolationLevel = value;
        }
    }
}