using AutoMapper;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots;
using Dotnet6.GraphQL4.Store.Services.Models.Products;

namespace Dotnet6.GraphQL4.Store.Services.Profiles.Converters
{
    public class BootModelToDomainConverter : ITypeConverter<BootModel, Boot>
    {
        private readonly IBootBuilder _builder;

        public BootModelToDomainConverter(IBootBuilder builder)
        {
            _builder = builder;
        }

        public Boot Convert(BootModel source, Boot destination, ResolutionContext context)
            => _builder
                .With(builder => builder.Type = source.Type)
                .With(builder => builder.Size = source.Size)
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