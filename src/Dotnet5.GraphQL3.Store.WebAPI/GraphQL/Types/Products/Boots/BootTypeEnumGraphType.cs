using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Boots
{
    public class BootTypeEnumGraphType : EnumerationGraphType<BootType>
    {
        public BootTypeEnumGraphType()
        {
            Name = "bootType";
            Description = "Boot Types";
        }
    }
}