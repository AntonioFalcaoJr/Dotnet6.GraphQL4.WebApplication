using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Backpacks
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