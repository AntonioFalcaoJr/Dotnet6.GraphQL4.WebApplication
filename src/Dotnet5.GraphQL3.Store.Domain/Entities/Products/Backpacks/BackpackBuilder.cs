using System;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Backpacks
{
    public class BackpackBuilder : ProductBuilder<Backpack, Guid>, IBackpackBuilder
    {
        private BackpackType _type;

        public override Backpack Build()
            => new(Id, Description, IntroduceAt, Name, PhotoUrl, Price, ProductType, Rating, Stock, Option, _type);

        public IBackpackBuilder WithType(BackpackType type)
        {
            _type = type;
            return this;
        }
    }
}