using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types
{
    public sealed class ProductGraphType : ObjectGraphType<Product>
    {
        public ProductGraphType()
        {
            Field(x => x.Id, false, typeof(GuidGraphType));
            Field(x => x.Description);
            Field(x => x.IntroduceAt);
            Field(x => x.Name);
            Field(x => x.PhotoFileName);
            Field(x => x.Price);

            //Field(x => x.ProductType);
            Field(x => x.Rating);
            Field(x => x.Stock);
        }
    }
}