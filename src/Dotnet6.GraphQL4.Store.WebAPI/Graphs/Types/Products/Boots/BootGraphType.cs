using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Boots
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