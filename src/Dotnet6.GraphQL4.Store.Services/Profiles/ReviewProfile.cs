using AutoMapper;
using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews;
using Dotnet6.GraphQL4.Store.Services.Profiles.Converters;

namespace Dotnet6.GraphQL4.Store.Services.Profiles
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