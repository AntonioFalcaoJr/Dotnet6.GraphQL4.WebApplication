using System;
using System.Collections.Generic;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Kayaks;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Services;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Kayaks
{
    public sealed class KayakGraphType : ObjectGraphType<Kayak>
    {
        public KayakGraphType()
        {
            Name = "kayak";

            Field(x => x.KayakType, type: typeof(KayakTypeEnumGraphType));
            Field(x => x.AmountOfPerson);

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

            Field<ListGraphType<ReviewGraphType>, IEnumerable<Review>>()
                .Name("reviews")
                .ResolveAsync(context
                    => context.RequestServices.GetRequiredService<IDataLoaderContextAccessor>()
                        .Context.GetOrAddCollectionBatchLoader<Guid, Review>(
                            loaderKey: "getLookupByProductIdsAsync",
                            fetchFunc: context.RequestServices
                                .GetRequiredService<IProductService>()
                                .GetLookupReviewsByProductIdsAsync)
                        .LoadAsync(context.Source.Id));

            Interface<ProductInterfaceGraphType>();
            IsTypeOf = o => o is Product;
        }
    }
}