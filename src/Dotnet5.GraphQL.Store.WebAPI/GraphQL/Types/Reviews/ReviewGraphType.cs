using Dotnet5.GraphQL.Store.Domain.Entities;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews
{
    public class ReviewGraphType : ObjectGraphType<Review>
    {
        public ReviewGraphType()
        {
            Name = "Review";

            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.Comment);
            Field(x => x.Title);
        }
    }
}