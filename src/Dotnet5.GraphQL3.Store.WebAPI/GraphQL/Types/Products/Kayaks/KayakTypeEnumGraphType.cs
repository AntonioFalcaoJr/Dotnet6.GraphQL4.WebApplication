using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Kayaks
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