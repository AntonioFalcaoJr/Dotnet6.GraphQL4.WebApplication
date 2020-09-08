using System;
using Dotnet5.GraphQL.Store.CrossCutting.Notifications;
using Dotnet5.GraphQL.Store.Services;
using Dotnet5.GraphQL.Store.Services.Messages;
using Dotnet5.GraphQL.Store.Services.Models;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Extensions;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public class StoreMutation : ObjectGraphType
    {
        public StoreMutation(IServiceProvider serviceProvider)
        {
            FieldAsync<ReviewGraphType>(
                name: "createReview",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ReviewInputGraphType>> {Name = "review"}),
                resolve: async context =>
                {
                    var model = context.GetArgument<ReviewModel>("review");

                    var review = await context.TryAsyncResolve(
                        resolve: async fieldContext
                            => await serviceProvider
                                .GetRequiredService<IProductService>()
                                .AddReviewAsync(
                                    reviewModel: model,
                                    cancellationToken: fieldContext.CancellationToken));

                    var notificationContext = serviceProvider.GetRequiredService<INotificationContext>();
                    if (notificationContext.HasNotifications)
                    {
                        context.Errors.AddRange(notificationContext.ExecutionErrors);
                        return default;
                    }

                    serviceProvider.GetScopedService<IReviewMessageService>()
                        .Add(model: model);

                    return review;
                });
        }
    }
}