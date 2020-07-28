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
        }
    }
}