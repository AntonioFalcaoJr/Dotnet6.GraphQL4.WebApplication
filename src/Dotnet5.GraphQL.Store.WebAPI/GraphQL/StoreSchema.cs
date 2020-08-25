using System;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Backpacks;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Boots;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Kayaks;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public class StoreSchema : Schema
    {
        public StoreSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<StoreQuery>();
            Mutation = provider.GetRequiredService<StoreMutation>();
            Subscription = provider.GetRequiredService<StoreSubscription>();

            RegisterType<BootGraphType>();
            RegisterType<BackpackGraphType>();
            RegisterType<KayakGraphType>();
        }
    }
}