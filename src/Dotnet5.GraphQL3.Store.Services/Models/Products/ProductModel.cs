using System;
using Dotnet5.GraphQL3.Services.Abstractions.Models;
using Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL3.Store.Services.Models.Products
{
    public abstract record ProductModel : Model<Guid>
    {
        public string Description { get; init; }
        public DateTimeOffset IntroduceAt { get; init; }
        public string Name { get; init; }
        public string PhotoUrl { get; init; }
        public decimal Price { get; init; }
        public ProductType ProductType { get; init; }
        public int Rating { get; init; }
        public int Stock { get; init; }
    }
}