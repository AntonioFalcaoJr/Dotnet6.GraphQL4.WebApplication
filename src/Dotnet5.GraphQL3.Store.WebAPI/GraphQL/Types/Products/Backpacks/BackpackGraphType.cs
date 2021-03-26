using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Backpacks;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Backpacks
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