using AutoMapper;
using Dotnet5.GraphQL.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL.Store.Services.Models;
using Dotnet5.GraphQL.Store.Services.Profiles.Converters;

namespace Dotnet5.GraphQL.Store.Services.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewModel, Review>()
                .ConvertUsing<ReviewModelToDomainConverter>();
        }
    }
}