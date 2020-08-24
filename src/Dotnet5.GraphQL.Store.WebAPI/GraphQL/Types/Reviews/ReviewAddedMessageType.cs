using Dotnet5.GraphQL.Store.Services.Messages;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews
{
    public class ReviewAddedMessageType : ObjectGraphType<ReviewMessage>
    {
        public ReviewAddedMessageType()
        {
            Name = "Review Added Message";

            Field(x => x.Title);
            Field(x => x.ProductId, type: typeof(GuidGraphType));
        }
    }
}