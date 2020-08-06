using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Backpacks;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Boots;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Products.Kayaks;
using GraphQL;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public class StoreSchema : Schema
    {
        public StoreSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<StoreQuery>();
            Mutation = resolver.Resolve<StoreMutation>();
            
            RegisterType<BootGraphType>();
            RegisterType<BackpackGraphType>();
            RegisterType<KayakGraphType>();
        }
    }
}