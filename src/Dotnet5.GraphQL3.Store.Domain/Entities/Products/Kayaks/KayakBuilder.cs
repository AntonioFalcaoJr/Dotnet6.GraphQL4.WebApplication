using System;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Kayaks
{
    public class KayakBuilder : ProductBuilder<Kayak, Guid>, IKayakBuilder
    {
        private int _amountOfPerson;
        private KayakType _type;

        public IKayakBuilder WithAmountOfPerson(int amountOfPerson)
        {
            _amountOfPerson = amountOfPerson;
            return this;
        }

        public IKayakBuilder WithType(KayakType type)
        {
            _type = type;
            return this;
        }

        public override Kayak Build()
            => new(Id, Description, IntroduceAt, Name, PhotoUrl, Price, ProductType, Rating, Stock, Option, _type, _amountOfPerson);
    }
}