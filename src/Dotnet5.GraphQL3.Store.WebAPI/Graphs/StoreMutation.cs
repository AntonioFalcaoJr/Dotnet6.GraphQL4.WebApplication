using Dotnet5.GraphQL3.Store.Services;
using Dotnet5.GraphQL3.Store.Services.Messages;
using Dotnet5.GraphQL3.Store.Services.Models.Reviews;
using Dotnet5.GraphQL3.Store.WebAPI.Graphs.Types.Reviews;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet5.GraphQL3.Store.WebAPI.Graphs
{
    public sealed class StoreMutation : ObjectGraphType
    {
        public StoreMutation()
        {
            Field<ReviewGraphType>()
                .Name("CreateReview")
                .Argument<ReviewInputGraphType>("review")
                .Resolve()
                .WithService<IProductService>()
                .ResolveAsync(
                    async (context, service) =>
                        {
                            var reviewModel = context.GetArgument<ReviewModel>("review");
            
                            var review = await service.AddReviewAsync(
                                reviewModel: reviewModel, 
                                cancellationToken: context.CancellationToken);
                            
                            if (review is {IsValid: true})
                                context.RequestServices.GetRequiredService<IReviewMessageService>().Add(reviewModel);
            
                            return review;
                        });
        }
    }
}