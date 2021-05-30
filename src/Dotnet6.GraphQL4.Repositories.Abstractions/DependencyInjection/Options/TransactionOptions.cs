using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Dotnet6.GraphQL4.Repositories.Abstractions.DependencyInjection.Options
{
    public class TransactionOptions
    {
        [Required, EnumDataType(typeof(IsolationLevel))]
        public IsolationLevel IsolationLevel { get; set; }
    }
}