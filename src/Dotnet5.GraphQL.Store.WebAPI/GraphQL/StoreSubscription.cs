using System;
using Dotnet5.GraphQL.Store.Services.Messages;
using Dotnet5.GraphQL.Store.Services.Models.Messages;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL.Resolvers;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public sealed class StoreSubscription : ObjectGraphType
    {
        public StoreSubscription(IServiceProvider serviceProvider)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "reviewAdded",
                Type = typeof(ReviewAddedMessageType),
                Resolver = new FuncFieldResolver<ReviewMessage>(resolver
                    => resolver.Source as ReviewMessage),
                Subscriber = new EventStreamResolver<ReviewMessage>(subscriber
                    => serviceProvider
                        .GetRequiredService<IReviewMessageService>()
                        .Messages())
            });
        }
    }
}