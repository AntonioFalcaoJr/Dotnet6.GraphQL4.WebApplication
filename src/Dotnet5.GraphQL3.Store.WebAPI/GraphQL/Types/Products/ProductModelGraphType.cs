using Dotnet5.GraphQL3.Store.Services.Models.Products;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products
{
    public sealed class ProductModelGraphType : ObjectGraphType<ProductModel>
    {
        public ProductModelGraphType()
        {
            Name = "productmodel";
            
            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.Description);
            Field(x => x.IntroduceAt);
            Field(x => x.Name).Description("The name of the product.");
            Field(x => x.PhotoUrl);
            Field(x => x.Price);
            Field(x => x.ProductType, type: typeof(ProductTypeGraphType));
            Field(x => x.Rating);
            Field(x => x.Stock);
            Field<ProductOptionEnumGraphType>("option");
        }
    }
}