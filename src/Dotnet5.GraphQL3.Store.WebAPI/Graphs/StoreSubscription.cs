using System;
using Dotnet5.GraphQL3.Store.Services.Messages;
using Dotnet5.GraphQL3.Store.Services.Models.Reviews.Messages;
using Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Reviews;
using GraphQL.Resolvers;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.Store.WebAPI.Graphs
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
                    AsyncSubscriber = new AsyncEventStreamResolver<ReviewMessage>(_ 
                        => serviceProvider
                            .GetRequiredService<IReviewMessageService>()
                            .MessagesAsync())
                });
        }
    }
}