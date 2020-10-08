using System;
using Dotnet5.GraphQL3.Domain.Abstractions.Builders;
using Dotnet5.GraphQL3.Domain.Abstractions.Entities;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products
{
    public abstract class ProductBuilder<TProduct, TId> : Builder<ProductBuilder<TProduct, TId>, TProduct, TId>, IProductBuilder<TProduct, TId>
        where TProduct : Entity<TId>, IProduct
        where TId : struct
    {
        protected string Description;
        protected DateTimeOffset IntroduceAt;
        protected string Name;
        protected Option Option;
        protected string PhotoUrl;
        protected decimal Price;
        protected ProductType ProductType;
        protected int Rating;
        protected int Stock;

        public IProductBuilder<TProduct, TId> WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public IProductBuilder<TProduct, TId> WithIntroduceAt(DateTimeOffset introduceAt)
        {
            IntroduceAt = introduceAt;
            return this;
        }

        public IProductBuilder<TProduct, TId> WithName(string name)
        {
            Name = name;
            return this;
        }

        public IProductBuilder<TProduct, TId> WithOption(Option option)
        {
            Option = option;
            return this;
        }

        public IProductBuilder<TProduct, TId> WithPhotoUrl(string photoUrl)
        {
            PhotoUrl = photoUrl;
            return this;
        }

        public IProductBuilder<TProduct, TId> WithPrice(decimal price)
        {
            Price = price;
            return this;
        }

        public IProductBuilder<TProduct, TId> WithProductType(ProductType productType)
        {
            ProductType = productType;
            return this;
        }

        public IProductBuilder<TProduct, TId> WithRating(int rating)
        {
            Rating = rating;
            return this;
        }

        public IProductBuilder<TProduct, TId> WithStock(int stock)
        {
            Stock = stock;
            return this;
        }
    }
}