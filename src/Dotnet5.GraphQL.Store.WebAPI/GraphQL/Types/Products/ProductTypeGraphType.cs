using Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products
{
    public class ProductTypeGraphType : ObjectGraphType<ProductType>
    {
        public ProductTypeGraphType()
        {
            Name = "Product Type";
            Field(x => x.Id, type: typeof(GuidGraphType));
        }
    }
}