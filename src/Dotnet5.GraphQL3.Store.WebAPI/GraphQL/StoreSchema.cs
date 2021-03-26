using System;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Backpacks;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Boots;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Products.Kayaks;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL
{
    public class StoreSchema : Schema
    {
        public StoreSchema(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<StoreQuery>();
            Mutation = serviceProvider.GetRequiredService<StoreMutation>();
            Subscription = serviceProvider.GetRequiredService<StoreSubscription>();

            RegisterType(typeof(BootGraphType));
            RegisterType(typeof(BackpackGraphType));
            RegisterType(typeof(KayakGraphType));
        }
    }
}