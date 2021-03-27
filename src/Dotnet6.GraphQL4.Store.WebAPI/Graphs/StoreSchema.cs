using System;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Backpacks;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Boots;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Products.Kayaks;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs
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