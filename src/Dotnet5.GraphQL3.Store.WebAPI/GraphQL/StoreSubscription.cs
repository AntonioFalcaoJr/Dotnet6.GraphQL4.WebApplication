using System;
using Dotnet5.GraphQL3.Store.Services.Messages;
using Dotnet5.GraphQL3.Store.Services.Models.Messages;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL
{
    public sealed class StoreSubscription : ObjectGraphType
    {
        public StoreSubscription(IServiceProvider serviceProvider)
        {
            Name = "Subscription";
            AddField(
                new EventStreamFieldType
                {
                    Name = "reviewAdded",
                    Type = typeof(ReviewAddedMessageType),
                    Resolver = new FuncFieldResolver<ReviewMessage>(fieldContext 
                        => fieldContext.Source as ReviewMessage),
                    AsyncSubscriber = new AsyncEventStreamResolver<ReviewMessage>(streamContext 
                        => serviceProvider
                            .GetRequiredService<IReviewMessageService>()
                            .MessagesAsync())
                });
        }
    }
}