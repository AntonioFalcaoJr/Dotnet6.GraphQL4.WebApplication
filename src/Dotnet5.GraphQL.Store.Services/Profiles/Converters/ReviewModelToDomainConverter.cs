using AutoMapper;
using Dotnet5.GraphQL.Store.Domain.Entities;
using Dotnet5.GraphQL.Store.Services.Models;

namespace Dotnet5.GraphQL.Store.Services.Profiles.Converters
{
    public class ReviewModelToDomainConverter : ITypeConverter<ReviewModel, Review>
    {
        public Review Convert(ReviewModel source, Review destination, ResolutionContext context)
        {
            return new Review();
        }
    }
}