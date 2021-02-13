using System;
using Dotnet5.GraphQL3.Repositories.Abstractions.Pages;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Services;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Pages;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL
{
    public sealed class StoreQuery : ObjectGraphType
    {
        public StoreQuery()
        {
            FieldAsync<PagedResultGraphType<ProductInterfaceGraphType, Product>>(
                name: "products",
                arguments: new QueryArguments(new QueryArgument<PageParamsGraphType> {Name = "pageParams"}),
                resolve: async context 
                    => await context.RequestServices
                        .GetRequiredService<IProductService>()
                        .GetAllAsync(
                            pageParams: context.GetArgument<PageParams>("pageParams"), 
                            cancellationToken: context.CancellationToken));

            FieldAsync<ProductInterfaceGraphType>(
                name: "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id"}),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    if (Equals(id, default(Guid))) context.Errors.Add(new ExecutionError($"Invalid Id: {id}"));

                    return await context.RequestServices
                        .GetRequiredService<IProductService>()
                        .GetByIdAsync(
                            id: id,
                            cancellationToken: context.CancellationToken);
                });

            FieldAsync<ListGraphType<ReviewGraphType>>(
                name: "reviews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "productId"}),
                resolve: async context =>
                {
                    var productId = context.GetArgument<Guid>("productId");
                    if (Equals(productId, default(Guid))) context.Errors.Add(new ExecutionError($"Invalid Id: {productId}"));

                    var product = await context.RequestServices
                        .GetRequiredService<IProductService>()
                        .GetByIdAsync(
                            id: productId,
                            include: products => products.Include(x => x.Reviews),
                            cancellationToken: context.CancellationToken);

                    return product?.Reviews;
                });
        }
    }
}