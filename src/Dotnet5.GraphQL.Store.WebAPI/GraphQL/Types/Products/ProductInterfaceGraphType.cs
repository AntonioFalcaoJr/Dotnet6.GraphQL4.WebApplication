using System;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Domain.Entities.Products.Backpacks;
using Dotnet5.GraphQL.Store.Domain.Entities.Products.Boots;
using Dotnet5.GraphQL.Store.Domain.Entities.Products.Kayaks;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Services;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Backpacks;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Boots;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Kayaks;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products
{
    public sealed class ProductInterfaceGraphType : InterfaceGraphType<Product>
    {
        public ProductInterfaceGraphType(BootGraphType bootGraphType, BackpackGraphType backpackGraphType, KayakGraphType kayakGraphType)
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

            FieldAsync<ListGraphType<ReviewGraphType>>(
                name: "reviews",
                resolve: async context => await context
                    .RequestServices.GetRequiredService<IDataLoaderContextAccessor>()
                    .Context.GetOrAddCollectionBatchLoader<Guid, Review>(
                        loaderKey: "getLookupByProductIdsAsync",
                        fetchFunc: context.RequestServices
                            .GetRequiredService<IProductService>()
                            .GetLookupReviewsByProductIdsAsync)
                    .LoadAsync(context.Source.Id));
            
            ResolveType = @object =>
            {
                return @object switch
                {
                    Boot _ => bootGraphType,
                    Backpack _ => backpackGraphType,
                    Kayak _ => kayakGraphType,
                    _ => default
                };
            };
        }
    }
}