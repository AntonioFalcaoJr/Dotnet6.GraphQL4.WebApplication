using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Backpacks
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