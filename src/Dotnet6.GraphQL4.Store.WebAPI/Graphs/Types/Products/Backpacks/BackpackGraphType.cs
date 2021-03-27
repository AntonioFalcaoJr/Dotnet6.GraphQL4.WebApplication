using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Backpacks
{
    public sealed class BackpackGraphType : ProductGraphType<Backpack>
    {
        public BackpackGraphType()
        {
            Name = "Backpack";
            Field(x => x.BackpackType, type: typeof(BackpakcTypeEnumGraphType));
        }
    }
}