using AutoMapper;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Services.Models;

namespace Dotnet5.GraphQL3.Store.Services.Profiles.Converters
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