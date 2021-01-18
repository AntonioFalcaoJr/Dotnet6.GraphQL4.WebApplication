using Dotnet5.GraphQL3.Store.Services;
using Dotnet5.GraphQL3.Store.Services.Messages;
using Dotnet5.GraphQL3.Store.Services.Models;
using Dotnet5.GraphQL3.Store.WebAPI.GraphQL.Types.Reviews;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace Dotnet5.GraphQL3.Store.WebAPI.GraphQL
{
    public class StoreMutation : ObjectGraphType
    {
        public StoreMutation()
        {
            FieldAsync<ReviewGraphType>(
                name: "createReview",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ReviewInputGraphType>> {Name = "review"}),
                resolve: async context =>
                {
                    var model = context.GetArgument<ReviewModel>("review");

                    var review = await context.RequestServices
                        .GetRequiredService<IProductService>()
                        .AddReviewAsync(
                            reviewModel: model, 
                            cancellationToken: context.CancellationToken);

                    if (review is {IsValid: true})
                        context.RequestServices.GetRequiredService<IReviewMessageService>().Add(model);

                    return review;
                });
        }
    }
}