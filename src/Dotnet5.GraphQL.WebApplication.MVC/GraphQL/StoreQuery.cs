using Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types;
using Dotnet5.GraphQL.WebApplication.Services;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL
{
    public sealed class StoreQuery : ObjectGraphType
    {
        public StoreQuery(IProductService service)
        {
            Field<ListGraphType<ProductGraphType>>("products",
                resolve: context
                    => service.GetAllAsync(x => x.Name != null));
        }
    }
}