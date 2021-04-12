using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks
{
    public class BackpackBuilder : ProductBuilder<BackpackBuilder, Backpack, Guid>, IBackpackBuilder
    {
        public BackpackType Type { get; set; }

        public override Backpack Build()
            => new(Id, Description, IntroduceAt, Name, PhotoUrl, Price, ProductType, Rating, Stock, Option, Type);
    }
}