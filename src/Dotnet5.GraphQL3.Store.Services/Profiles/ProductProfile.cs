using AutoMapper;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Kayaks;
using Dotnet5.GraphQL3.Store.Services.Models;
using Dotnet5.GraphQL3.Store.Services.Profiles.Converters;

namespace Dotnet5.GraphQL3.Store.Services.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, Kayak>().
                ConvertUsing<ProductModelToDomainProfile>();
        }
    }
}