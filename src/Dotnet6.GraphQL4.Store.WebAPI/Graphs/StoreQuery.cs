using System;
using Dotnet6.GraphQL4.Store.Services;
using Dotnet6.GraphQL4.Repositories.Abstractions.Pages;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Pages;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Reviews;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs
{
    public sealed class StoreQuery : ObjectGraphType
    {
        public StoreQuery()
        {
            Field<PagedResultGraphType<ProductInterfaceGraphType, Product>>()
                .Name("Products")
                .Argument<PageParamsGraphType>(nameof(PageParams))
                .Resolve()
                .WithService<IProductService>()
                .ResolveAsync(
                    async (context, service) 
                        => await service.GetAllAsync(
                            pageParams: context.GetArgument<PageParams>(nameof(PageParams)), 
                            cancellationToken: context.CancellationToken));

            Field<ProductInterfaceGraphType>()
                .Name("Product")
                .Argument<GuidGraphType>("id")
                .Resolve()
                .WithService<IProductService>()
                .ResolveAsync(
                    async (context, service) 
                        => await service.GetByIdAsync(
                            id: context.GetArgument<Guid>("id"), 
                            cancellationToken: context.CancellationToken));


            Field<ListGraphType<ReviewGraphType>>()
                .Name("Reviews")
                .Argument<GuidGraphType>("productId")
                .Resolve()
                .WithService<IProductService>()
                .ResolveAsync(
                    async (context, service) =>
                        {
                            var product = await service.GetByIdAsync(
                                id: context.GetArgument<Guid>("productId"),
                                include: products => products.Include(x => x.Reviews),
                                cancellationToken: context.CancellationToken);

                            return product?.Reviews;
                        });
        }
    }
}