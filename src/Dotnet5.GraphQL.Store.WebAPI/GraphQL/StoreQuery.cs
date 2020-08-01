using System;
using Dotnet5.GraphQL.Store.Services;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products;
using GraphQL.Execution;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public sealed class StoreQuery : ObjectGraphType
    {
        public StoreQuery(IProductService productService)
        {
            FieldAsync<ListGraphType<ProductInterfaceGraphType>>("products",
                resolve: async context
                    => await productService.GetAllAsync(x => x.Name != null, context.CancellationToken));

            FieldAsync<ProductInterfaceGraphType>("product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id"}),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    if (Equals(id, default(Guid))) context.Errors.Add(new InvalidValueException("Id", $"Value: {id}"));
                    return await productService.GetByIdAsync(id, context.CancellationToken);
                });
        }
    }
}