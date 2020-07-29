using System;
using Dotnet5.GraphQL.WebApplication.Domain.Abstractions;
using Dotnet5.GraphQL.WebApplication.Domain.Enumerations;
using Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes;
using FluentValidation;

namespace Dotnet5.GraphQL.WebApplication.Domain.Entities.Products
{
    public class Product : Entity<Guid>
    {
        protected Product(Guid id, string description, DateTimeOffset introduceAt, string name, string photoFileName, decimal price,
            ProductType productType, int rating, int stock, Option option)
        {
            Id = id;
            Description = description;
            IntroduceAt = introduceAt;
            Name = name;
            PhotoFileName = photoFileName;
            Price = price;
            ProductType = productType;
            Rating = rating;
            Stock = stock;
            Option = option;

            Validate(this, new InlineValidator<Product>());
        }

        protected Product() { }

        public string Description { get; }
        public DateTimeOffset IntroduceAt { get; }
        public string Name { get; }
        public Option Option { get; }
        public string PhotoFileName { get; }
        public decimal Price { get; }
        public ProductType ProductType { get; }
        public int Rating { get; }
        public int Stock { get; }
    }
}