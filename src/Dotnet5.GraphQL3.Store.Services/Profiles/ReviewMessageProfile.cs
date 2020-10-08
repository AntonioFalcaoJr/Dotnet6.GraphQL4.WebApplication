using AutoMapper;
using Dotnet5.GraphQL3.Store.Services.Models;
using Dotnet5.GraphQL3.Store.Services.Models.Messages;

namespace Dotnet5.GraphQL3.Store.Services.Profiles
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