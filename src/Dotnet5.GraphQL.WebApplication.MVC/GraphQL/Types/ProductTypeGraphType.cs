using Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types
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