using AutoMapper;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Services.Models;
using Dotnet5.GraphQL3.Store.Services.Profiles.Converters;

namespace Dotnet5.GraphQL3.Store.Services.Profiles
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