using Dotnet5.GraphQL.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Backpacks
{
    public class BackpakcTypeEnumGraphType : EnumerationGraphType<BackpackType>
    {
        public BackpakcTypeEnumGraphType()
        {
            Name = "backpackType";
            Description = "Backpack types";
        }
    }
}