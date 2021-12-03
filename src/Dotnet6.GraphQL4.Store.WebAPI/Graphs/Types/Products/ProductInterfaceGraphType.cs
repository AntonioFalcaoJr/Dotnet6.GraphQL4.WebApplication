using System;
using System.Collections.Generic;
using Dotnet6.GraphQL4.Store.Services;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks;
using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Backpacks;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Boots;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Kayaks;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Reviews;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products;

public sealed class ProductInterfaceGraphType : InterfaceGraphType<Product>
{
    public ProductInterfaceGraphType(IServiceProvider serviceProvider)
    {
        Name = "product";

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

        Field<ListGraphType<ReviewGraphType>, IEnumerable<Review>>()
            .Name("reviews")
            .ResolveAsync(context 
                => context.RequestServices
                    .GetRequiredService<IDataLoaderContextAccessor>().Context
                    .GetOrAddCollectionBatchLoader<Guid, Review>(
                        loaderKey: "getLookupReviewsByProductIdsAsync",
                        fetchFunc: context.RequestServices
                            .GetRequiredService<IProductService>()
                            .GetLookupReviewsByProductIdsAsync)
                    .LoadAsync(context.Source.Id));

        ResolveType = @object =>
        {
            return @object switch
            {
                Boot => serviceProvider.GetRequiredService<BootGraphType>(),
                Backpack => serviceProvider.GetRequiredService<BackpackGraphType>(),
                Kayak => serviceProvider.GetRequiredService<KayakGraphType>(),
                _ => default
            };
        };
    }
}