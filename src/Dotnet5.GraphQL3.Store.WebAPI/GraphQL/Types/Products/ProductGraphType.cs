using System;
using System.Collections.Generic;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Services;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL.DataLoader;
using GraphQL.MicrosoftDI;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products
{
    public abstract class ProductGraphType<T> : ObjectGraphType<T>
    where T: Product
    {
        protected ProductGraphType()
        {
            Interface<ProductInterfaceGraphType>();
            IsTypeOf = o => o is Product;

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
        }
    }
}