using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks
{
    public class KayakBuilder : ProductBuilder<KayakBuilder, Kayak, Guid>, IKayakBuilder
    {
        public int AmountOfPerson { get; set; }
        public KayakType Type { get; set; }

        public override Kayak Build()
            => new(Id, Description, IntroduceAt, Name, PhotoUrl, Price, ProductType, Rating, Stock, Option, Type, AmountOfPerson);
    }
}