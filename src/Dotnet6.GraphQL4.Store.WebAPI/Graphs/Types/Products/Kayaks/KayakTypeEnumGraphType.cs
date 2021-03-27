using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Kayaks
{
    public class KayakTypeEnumGraphType : EnumerationGraphType<KayakType>
    {
        public KayakTypeEnumGraphType()
        {
            Name = "kayakType";
            Description = "Kayak types";
        }
    }
}