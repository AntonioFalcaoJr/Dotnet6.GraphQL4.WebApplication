using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Boots;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Boots
{
    public sealed class BootGraphType : ProductGraphType<Boot>
    {
        public BootGraphType()
        {
            Name = "boot";
            Field(x => x.Size);
            Field(x => x.BootType, type: typeof(BootTypeEnumGraphType));
        }
    }
}