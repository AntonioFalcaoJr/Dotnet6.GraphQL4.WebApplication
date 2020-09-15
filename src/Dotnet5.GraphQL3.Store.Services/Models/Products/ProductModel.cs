using System;
using Dotnet5.GraphQL3.Services.Abstractions.Models;
using Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL3.Store.Services.Models.Products
{
    public abstract class ProductModel : Model<Guid>
    {
        public string Description { get; set; }
        public DateTimeOffset IntroduceAt { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
        public int Rating { get; set; }
        public int Stock { get; set; }
    }
}