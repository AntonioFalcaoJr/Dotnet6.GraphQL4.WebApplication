using System;
using Dotnet5.GraphQL.Store.Services;
using Dotnet5.GraphQL.Store.Services.Messages;
using Dotnet5.GraphQL.Store.Services.Models;
using Dotnet5.GraphQL.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL.Store.WebAPI.GraphQL
{
    public class StoreMutation : ObjectGraphType
    {
        public StoreMutation(IServiceProvider provider)
        {
            FieldAsync<ReviewGraphType>(
                "createReview",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ReviewInputGraphType>> {Name = "review"}),
                resolve: async context =>
                {
                    var model = context.GetArgument<ReviewModel>("review");

                    var review = await context.TryAsyncResolve(async fieldContext
                        => await provider
                            .GetRequiredService<IProductService>()
                            .AddReviewAsync(model, fieldContext.CancellationToken));

                    provider.GetRequiredService<IReviewMessageService>().Add(model);
                    return review;
                });
        }
    }
}