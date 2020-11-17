using System;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Boots
{
    public class BootBuilder : ProductBuilder<Boot, Guid>, IBootBuilder
    {
        private int _size;
        private BootType _type;

        public override Boot Build()
            => new(Id, Description, IntroduceAt, Name, PhotoUrl, Price, ProductType, Rating, Stock, Option, _type, _size);

        public IBootBuilder WithType(BootType type)
        {
            _type = type;
            return this;
        }

        public IBootBuilder WithSize(int size)
        {
            _size = size;
            return this;
        }
    }
}