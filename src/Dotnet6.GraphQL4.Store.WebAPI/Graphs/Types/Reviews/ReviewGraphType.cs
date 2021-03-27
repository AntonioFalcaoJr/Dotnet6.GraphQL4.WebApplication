using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;
using GraphQL.Types;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Reviews
{
    public sealed class ReviewGraphType : ObjectGraphType<Review>
    {
        public ReviewGraphType()
        {
            Name = "Review";
            Field(x => x.Id, type: typeof(GuidGraphType));
            Field(x => x.ProductId, type: typeof(GuidGraphType));
            Field(x => x.Comment);
            Field(x => x.Title);
        }
    }
}