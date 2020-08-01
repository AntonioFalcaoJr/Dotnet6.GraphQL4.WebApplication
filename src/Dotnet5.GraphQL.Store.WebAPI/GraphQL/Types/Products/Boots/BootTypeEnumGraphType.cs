using Dotnet5.GraphQL.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Boots
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