using AutoMapper;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks;
using Dotnet6.GraphQL4.Store.Services.Models.Products;

namespace Dotnet6.GraphQL4.Store.Services.Profiles.Converters
{
    public class BackpackModelToDomainConverter : ITypeConverter<BackpackModel, Backpack>
    {
        private readonly IBackpackBuilder _builder;

        public BackpackModelToDomainConverter(IBackpackBuilder builder)
        {
            _builder = builder;
        }

        public Backpack Convert(BackpackModel source, Backpack destination, ResolutionContext context)
            => _builder
                .WithType(source.Type)
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