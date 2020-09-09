using System;
using System.Collections.Generic;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Domain.Entities.Products.Boots;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Services;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Extensions;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Boots
{
    public sealed class BootGraphType : ObjectGraphType<Boot>
    {
        public BootGraphType(IServiceProvider serviceProvider, IDataLoaderContextAccessor accessor)
        {
            Name = "boot";

            Field(x => x.Size);
            Field(x => x.BootType, type: typeof(BootTypeEnumGraphType));

            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.Description);
            Field(x => x.IntroduceAt);
            Field(x => x.Name).Description("The name of the product.");
            Field(x => x.PhotoUrl);
            Field(x => x.Price);
            Field(x => x.ProductType, type: typeof(ProductTypeGraphType));
            Field(x => x.Rating);
            Field(x => x.Stock);
            Field<ProductOptionEnumGraphType>("Option");

            Field<ReviewGraphType, IEnumerable<Review>>()
                .Name("ssss")
                .ResolveAsync(context =>
                    accessor.Context
                        .GetOrAddCollectionBatchLoader<Guid, Review>(
                            loaderKey: "getLookupByProductIdsAsync",
                            fetchFunc: serviceProvider
                                .GetRequiredService<IReviewService>()
                                .GetLookupByProductIdsAsync)
                        .LoadAsync(context.Source.Id));

            Interface<ProductInterfaceGraphType>();
            IsTypeOf = o => o is Product;
        }
    }
}