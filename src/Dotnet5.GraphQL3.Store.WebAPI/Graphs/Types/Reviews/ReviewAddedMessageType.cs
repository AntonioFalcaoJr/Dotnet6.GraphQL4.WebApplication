using Dotnet5.GraphQL3.Store.Services.Models.Reviews.Messages;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Reviews
{
    public sealed class ReviewAddedMessageType : ObjectGraphType<ReviewMessage>
    {
        public ReviewAddedMessageType()
        {
            Name = "reviewAddedMessage";

            Field(x => x.Title);
            Field(x => x.ProductId, type: typeof(GuidGraphType));
        }
    }
}