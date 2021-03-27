using System;
using System.Collections.Generic;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;
using Dotnet6.GraphQL4.Store.Domain.Entities.Reviews;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products
{
    public abstract class Product : Entity<Guid>, IProduct
    {
        private readonly HashSet<Review> _reviews = new();

        protected Product(Guid id, string description, DateTimeOffset introduceAt, string name, string photoUrl, decimal price, ProductType productType, int rating, int stock, Option option)
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
        }

        protected Product() { }

        public IReadOnlyCollection<Review> Reviews
             => _reviews;

        public string Description { get; }
        public DateTimeOffset IntroduceAt { get; }
        public string Name { get; }
        public Option Option { get; }
        public string PhotoUrl { get; }
        public decimal Price { get; }
        public ProductType ProductType { get; }
        public int Rating { get; }
        public int Stock { get; }

        public void AddReview(Review review)
        {
            if (review is null || review.IsValid is false)
            {
                AddError(Resource.Product_Item_Invalid, review?.ValidationResult);
                return;
            }

            if (_reviews.Contains(review)) return;
            _reviews.Add(review);
        }
    }
}