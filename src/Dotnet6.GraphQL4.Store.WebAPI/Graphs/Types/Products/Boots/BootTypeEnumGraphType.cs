using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Boots
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