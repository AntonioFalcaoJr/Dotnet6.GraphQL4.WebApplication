using Dotnet6.GraphQL4.Store.Services;
using Dotnet6.GraphQL4.Store.Services.Messages;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews;
using Dotnet6.GraphQL4.Store.WebAPI.Graphs.Types.Reviews;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet6.GraphQL4.Store.WebAPI.Graphs
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