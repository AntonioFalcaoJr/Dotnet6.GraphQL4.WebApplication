using System;
using System.Collections.Generic;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Backpacks;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Boots;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Kayaks;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Services;
using Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Products.Backpacks;
using Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Products.Boots;
using Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Products.Kayaks;
using Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Reviews;
using GraphQL.DataLoader;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Products
{
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
                .Name("Reviews")
                .Resolve()
                .WithServices<IDataLoaderContextAccessor, IProductService>()
                .ResolveAsync((context, dataLoader, service) =>
                    {
                        var loaderResult = dataLoader.Context
                            .GetOrAddCollectionBatchLoader<Guid, Review>(
                                loaderKey: "getLookupByProductIdsAsync",
                                fetchFunc: service.GetLookupReviewsByProductIdsAsync)
                            .LoadAsync(context.Source.Id);

                        return loaderResult.GetResultAsync();
                    });

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
}