using AutoMapper;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Kayaks;
using Dotnet5.GraphQL3.Store.Services.Models;

namespace Dotnet5.GraphQL3.Store.Services.Profiles.Converters
{
    public class ProductModelToDomainProfile : ITypeConverter<ProductModel, Kayak>
    {
        private readonly IKayakBuilder _builder;

        public ProductModelToDomainProfile(IKayakBuilder builder)
        {
            _builder = builder;
        }
        
        public Kayak Convert(ProductModel source, Kayak destination, ResolutionContext context) 
            => _builder
                .WithDescription(source.Description)
                .WithName(source.Name)
                .WithPrice(source.Price)
                .WithRating(source.Rating)
                .WithStock(source.Stock)
                .WithIntroduceAt(source.IntroduceAt)
                .WithPhotoUrl(source.PhotoUrl)
                .WithProductType(source.ProductType)
                .Build();
    }
}