using AutoMapper;
using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews;

namespace Dotnet6.GraphQL4.Store.Services.Profiles.Converters
{
    public class ReviewModelToDomainConverter : ITypeConverter<ReviewModel, Review>
    {
        private readonly IReviewBuilder _builder;

        public ReviewModelToDomainConverter(IReviewBuilder builder)
        {
            _builder = builder;
        }

        public Review Convert(ReviewModel source, Review destination, ResolutionContext context)
            => _builder
                .WithComment(source.Comment)
                .WithTitle(source.Title)
                .WithProductReference(source.ProductId)
                .Build();
    }
}