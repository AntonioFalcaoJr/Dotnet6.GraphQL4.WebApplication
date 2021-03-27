using AutoMapper;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews;
using Dotnet6.GraphQL4.Store.Services.Models.Reviews.Messages;

namespace Dotnet6.GraphQL4.Store.Services.Profiles
{
    public class ReviewMessageProfile : Profile
    {
        public ReviewMessageProfile()
        {
            CreateMap<ReviewModel, ReviewMessage>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId));
        }
    }
}