using Dotnet5.GraphQL.WebApplication.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types.Products.Kayaks
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