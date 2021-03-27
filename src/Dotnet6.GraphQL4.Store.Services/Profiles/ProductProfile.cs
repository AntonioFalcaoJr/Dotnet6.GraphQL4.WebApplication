using AutoMapper;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks;
using Dotnet6.GraphQL4.Store.Services.Models.Products;
using Dotnet6.GraphQL4.Store.Services.Profiles.Converters;

namespace Dotnet6.GraphQL4.Store.Services.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<KayakModel, Kayak>()
                .ConvertUsing<KayakModelToDomainConverter>();

            CreateMap<BootModel, Boot>()
                .ConvertUsing<BootModelToDomainConverter>();

            CreateMap<BackpackModel, Backpack>()
                .ConvertUsing<BackpackModelToDomainConverter>();
        }
    }
}