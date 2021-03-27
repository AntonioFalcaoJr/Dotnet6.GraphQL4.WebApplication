using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products
{
    public sealed class ProductTypeGraphType : ObjectGraphType<ProductType>
    {
        public ProductTypeGraphType()
        {
            Name = "productType";
            Field(x => x.Id, type: typeof(GuidGraphType));
        }
    }
}