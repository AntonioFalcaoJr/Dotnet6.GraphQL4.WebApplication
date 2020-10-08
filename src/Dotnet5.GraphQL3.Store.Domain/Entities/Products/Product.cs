using System;
using System.Collections.Generic;
using Dotnet5.GraphQL3.Domain.Abstractions.Entities;
using Dotnet5.GraphQL3.Store.Domain.Entities.Reviews;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products
{
    public abstract class Product : Entity<Guid>, IProduct
    {
        protected Product(Guid id, string description, DateTimeOffset introduceAt, string name, string photoUrl, decimal price,
            ProductType productType, int rating, int stock, Option option)
        {
            Id = id;
            Description = description;
            IntroduceAt = introduceAt;
            Name = name;
            PhotoUrl = photoUrl;
            Price = price;
            ProductType = productType;
            Rating = rating;
            Stock = stock;
            Option = option;
            Reviews = new List<Review>();
        }

        protected Product() { }

        public string Description { get; }
        public DateTimeOffset IntroduceAt { get; }
        public string Name { get; }
        public Option Option { get; }
        public string PhotoUrl { get; }
        public decimal Price { get; }
        public ProductType ProductType { get; }
        public int Rating { get; }
        public int Stock { get; }
        public ICollection<Review> Reviews { get; }

        public void AddReview(Review review)
        {
            if (review is null || review.IsValid is false)
            {
                AddError(Resource.Product_Item_Invalid, review?.ValidationResult);
                return;
            }

            if (Reviews.Contains(review)) return;
            Reviews.Add(review);
        }
    }
}