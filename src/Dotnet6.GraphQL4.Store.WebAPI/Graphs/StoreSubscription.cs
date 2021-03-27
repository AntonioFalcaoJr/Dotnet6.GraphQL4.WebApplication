using System;
using Dotnet6.GraphQL4.Store.Services.Messages;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews.Messages;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Reviews;
using GraphQL.Resolvers;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs
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