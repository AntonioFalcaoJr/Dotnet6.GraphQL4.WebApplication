using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Reviews
{
    public sealed class ReviewGraphType : ObjectGraphType<Review>
    {
        public ReviewGraphType()
        {
            Name = "review";

            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.ProductId, type: typeof(GuidGraphType));
            Field(x => x.Comment);
            Field(x => x.Title);
        }
    }
}