using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products
{
    public abstract class ProductBuilder<TProductBuilder, TProduct, TId> : Builder<TProductBuilder, TProduct, TId>, IProductBuilder<TProductBuilder, TProduct, TId>
        where TProductBuilder : ProductBuilder<TProductBuilder, TProduct, TId>
        where TProduct : Entity<TId>, IProduct
        where TId : struct
    {
        public string Description { get; set; }
        public DateTimeOffset IntroduceAt { get; set; }
        public string Name { get; set; }
        public Option Option { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
        public int Rating { get; set; }
        public int Stock { get; set; }
    }
}