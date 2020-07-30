using Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types.Products.Backpacks;
using Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types.Products.Boots;
using Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types.Products.Kayaks;
using GraphQL;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL
{
    public class StoreSchema : Schema
    {
        public StoreSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<StoreQuery>();
            RegisterType<BootGraphType>();
            RegisterType<BackpackGraphType>();
            RegisterType<KayakGraphType>();
        }
    }
}