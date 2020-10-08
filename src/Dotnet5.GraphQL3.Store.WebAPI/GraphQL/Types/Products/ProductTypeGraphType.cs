using Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products
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