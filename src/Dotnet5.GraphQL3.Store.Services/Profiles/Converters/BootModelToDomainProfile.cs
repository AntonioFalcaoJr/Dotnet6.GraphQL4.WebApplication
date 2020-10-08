using AutoMapper;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products.Boots;
using Dotnet5.GraphQL3.Store.Services.Models.Products;

namespace Dotnet5.GraphQL3.Store.Services.Profiles.Converters
{
    public class BootModelToDomainProfile : ITypeConverter<BootModel, Boot>
    {
        private readonly IBootBuilder _builder;

        public BootModelToDomainProfile(IBootBuilder builder)
        {
            _builder = builder;
        }

        public Boot Convert(BootModel source, Boot destination, ResolutionContext context)
            => _builder
                .WithType(source.Type)
                .WithSize(source.Size)
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