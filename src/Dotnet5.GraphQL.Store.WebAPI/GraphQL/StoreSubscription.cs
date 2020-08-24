using Dotnet5.GraphQL.Store.Services.Messages;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public sealed class StoreSubscription : ObjectGraphType
    {
        public StoreSubscription(IReviewMessageService messageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "reviewAdded",
                Type = typeof(ReviewAddedMessageType),
                Resolver = new FuncFieldResolver<ReviewMessage>(c
                    => c.Source as ReviewMessage),
                Subscriber = new EventStreamResolver<ReviewMessage>(c
                    => messageService.Get())
            });
        }
    }
}