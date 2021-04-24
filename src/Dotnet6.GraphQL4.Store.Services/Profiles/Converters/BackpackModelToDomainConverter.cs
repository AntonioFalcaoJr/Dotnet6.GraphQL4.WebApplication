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
                .With(builder => builder.Type = source.Type)
                .With(builder => builder.Description = source.Description)
                .With(builder => builder.Name = source.Name)
                .With(builder => builder.Price = source.Price)
                .With(builder => builder.Rating = source.Rating)
                .With(builder => builder.Stock = source.Stock)
                .With(builder => builder.IntroduceAt = source.IntroduceAt)
                .With(builder => builder.PhotoUrl = source.PhotoUrl)
                .With(builder => builder.ProductType = source.ProductType)
                .Build();
    }
}