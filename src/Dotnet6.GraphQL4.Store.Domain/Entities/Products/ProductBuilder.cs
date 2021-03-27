using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products
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