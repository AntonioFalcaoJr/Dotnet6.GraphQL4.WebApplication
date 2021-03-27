using AutoMapper;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks;
using Dotnet6.GraphQL4.Store.Services.Models.Products;

namespace Dotnet6.GraphQL4.Store.Services.Profiles.Converters
{
    public class KayakModelToDomainConverter : ITypeConverter<KayakModel, Kayak>
    {
        private readonly IKayakBuilder _builder;

        public KayakModelToDomainConverter(IKayakBuilder builder)
        {
            _builder = builder;
        }

        public Kayak Convert(KayakModel source, Kayak destination, ResolutionContext context)
            => _builder
                .WithType(source.Type)
                .WithAmountOfPerson(source.AmountOfPerson)
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