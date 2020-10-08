using Dotnet5.GraphQL3.Store.Services.Models.Messages;
using GraphQL.Types;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Reviews
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