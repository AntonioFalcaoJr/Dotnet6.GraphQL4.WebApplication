using System;
using Dotnet5.GraphQL.Store.Services;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public sealed class StoreQuery : ObjectGraphType
    {
        public StoreQuery(IProductService productService, IReviewService reviewService)
        {
            FieldAsync<ListGraphType<ProductInterfaceGraphType>>("products",
                resolve: async context
                    => await productService.GetAllAsync(product => product, cancellationToken: context.CancellationToken));

            FieldAsync<ProductInterfaceGraphType>("product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id"}),
                resolve: async context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    if (Equals(id, default(Guid))) context.Errors.Add(new InvalidValueException("Id", $"Value: {id}"));
                    return await productService.GetByIdAsync(id, cancellationToken: context.CancellationToken);
                });

            FieldAsync<ListGraphType<ReviewGraphType>>("reviews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "productId"}),
                resolve: async context =>
                {
                    var productId = context.GetArgument<Guid>("productId");
                    if (Equals(productId, default(Guid))) context.Errors.Add(new InvalidValueException("productId", $"Value: {productId}"));
                    return await reviewService.GetAllAsync(review => review, review => review.ProductId == productId,
                        cancellationToken: context.CancellationToken);
                });
        }
    }
}