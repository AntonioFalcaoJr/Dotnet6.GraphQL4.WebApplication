using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots
{
    public class BootBuilder : ProductBuilder<BootBuilder, Boot, Guid>, IBootBuilder
    {
        public BootType Type { get; set; }
        public int Size { get; set; }

        public override Boot Build()
            => new(Id, Description, IntroduceAt, Name, PhotoUrl, Price, ProductType, Rating, Stock, Option, Type, Size);
    }
}