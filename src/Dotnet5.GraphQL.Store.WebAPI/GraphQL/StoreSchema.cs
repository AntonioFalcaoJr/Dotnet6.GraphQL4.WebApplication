using System;
using Dotnet5.GraphQL.Store.Services;
using Dotnet5.GraphQL.Store.Services.Messages;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Backpacks;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Boots;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Kayaks;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public class StoreSchema : Schema
    {
        public StoreSchema(
            IServiceProvider provider,
            IProductService productService,
            IReviewService reviewService,
            IReviewMessageService messageService)
            : base(provider)
        {
            Query = new StoreQuery(productService, reviewService);
            Mutation = new StoreMutation(productService, messageService);
            Subscription = new StoreSubscription(messageService);

            RegisterType<BootGraphType>();
            RegisterType<BackpackGraphType>();
            RegisterType<KayakGraphType>();
        }
    }
}