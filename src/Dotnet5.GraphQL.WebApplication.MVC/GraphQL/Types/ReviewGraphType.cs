using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using GraphQL.Types;

namespace Dotnet5.GraphQL.WebApplication.MVC.GraphQL.Types
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