using System;
using Dotnet5.GraphQL.Store.Services;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public sealed class StoreQuery : ObjectGraphType
    {
        public StoreQuery(IServiceProvider provider)
        {
            FieldAsync<ListGraphType<ProductInterfaceGraphType>>(
                "products",
                resolve: async context
                    => await provider
                        .GetRequiredService<IProductService>()
                        .GetAllAsync(
                            selector: product => product,
                            cancellationToken: context.CancellationToken));

            FieldAsync<ProductInterfaceGraphType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id"}),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    if (Equals(id, default(Guid))) context.Errors.Add(new InvalidValueException("Id", $"Value: {id}"));

                    return await provider
                        .GetRequiredService<IProductService>()
                        .GetByIdAsync(
                            id: id,
                            cancellationToken: context.CancellationToken);
                });

            FieldAsync<ListGraphType<ReviewGraphType>>(
                "reviews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "productId"}),
                resolve: async context =>
                {
                    var productId = context.GetArgument<Guid>("productId");
                    if (Equals(productId, default(Guid))) context.Errors.Add(new InvalidValueException("productId", $"Value: {productId}"));

                    return await provider
                        .GetRequiredService<IReviewService>()
                        .GetAllAsync(
                            selector: review => review,
                            predicate: review => review.ProductId == productId,
                            cancellationToken: context.CancellationToken);
                });
        }
    }
}