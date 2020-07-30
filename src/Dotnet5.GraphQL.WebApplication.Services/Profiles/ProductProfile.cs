using AutoMapper;
using Dotnet5.GraphQL.WebApplication.Domain.Entities.Products;
using Dotnet5.GraphQL.WebApplication.Services.Models;

namespace Dotnet5.GraphQL.WebApplication.Services.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductModel, Product>().ReverseMap();
        }
    }
}