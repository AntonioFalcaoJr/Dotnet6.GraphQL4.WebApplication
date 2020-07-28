using Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types;
using Dotnet5.GraphQL.WebApplication.Services;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL
{
    public sealed class StoreQuery : ObjectGraphType
    {
        public StoreQuery(IProductService service)
        {
            FieldAsync<ListGraphType<ProductGraphType>>("products",
                resolve: async context
                    => await service.GetAllAsync(x => x.Name != null));
        }
    }
}