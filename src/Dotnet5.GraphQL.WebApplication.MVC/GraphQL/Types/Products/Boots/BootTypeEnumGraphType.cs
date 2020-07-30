using Dotnet5.GraphQL.WebApplication.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types.Products.Boots
{
    public class BootTypeEnumGraphType : EnumerationGraphType<BootType>
    {
        public BootTypeEnumGraphType()
        {
            Name = "Boot Type";
            Description = "Boot Types";
        }
    }
}