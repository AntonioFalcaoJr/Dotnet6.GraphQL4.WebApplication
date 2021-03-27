using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks
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