using Dotnet5.GraphQL.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Kayaks
{
    public class KayakTypeEnumGraphType : EnumerationGraphType<KayakType>
    {
        public KayakTypeEnumGraphType()
        {
            Name = "Kayak type";
            Description = "Kayak types";
        }
    }
}