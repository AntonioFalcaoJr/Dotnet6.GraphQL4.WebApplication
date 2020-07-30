using System;
using Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types;
using Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types.Products;
using Dotnet5.GraphQL.WebApplication.Services;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL
{
    public sealed class StoreQuery : ObjectGraphType
    {
        public StoreQuery(IProductService productService)
        {
            FieldAsync<ListGraphType<ProductInterfaceGraphType>>("products",
                resolve: async context
                    => await productService.GetAllAsync(x => x.Name != null));

            FieldAsync<ProductInterfaceGraphType>("product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id"}),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    return await productService.GetByIdAsync(id);
                });
        }
    }
}