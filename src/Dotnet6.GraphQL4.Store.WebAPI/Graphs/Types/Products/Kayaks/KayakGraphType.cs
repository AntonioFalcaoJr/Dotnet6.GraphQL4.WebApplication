using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Kayaks
{
    public sealed class KayakGraphType : ProductGraphType<Kayak>
    {
        public KayakGraphType()
        {
            Name = "kayak";
            Field(x => x.KayakType, type: typeof(KayakTypeEnumGraphType));
            Field(x => x.AmountOfPerson);
        }
    }
}