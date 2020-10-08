using AutoMapper;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Backpacks;
using Dotnet5.GraphQL3.Store.Services.Models.Products;

namespace Dotnet5.GraphQL3.Store.Services.Profiles.Converters
{
    public class BackpackModelToDomainProfile : ITypeConverter<BackpackModel, Backpack>
    {
        private readonly IBackpackBuilder _builder;

        public BackpackModelToDomainProfile(IBackpackBuilder builder)
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