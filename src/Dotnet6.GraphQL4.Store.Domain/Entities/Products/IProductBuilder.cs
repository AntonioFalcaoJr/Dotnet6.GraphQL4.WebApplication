using System;
using Dotnet6.GraphQL4.Domain.Abstractions.Builders;
using Dotnet6.GraphQL4.Domain.Abstractions.Entities;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products
{
    public interface IProductBuilder<out TBuilder, out TProduct, TId> : IBuilder<TBuilder, TProduct, TId>
        where TBuilder : IBuilder<TBuilder, TProduct, TId>
        where TProduct : Entity<TId>, IProduct
        where TId : struct
    {
        string Description { set; }
        DateTimeOffset IntroduceAt { set; }
        string Name { set; }
        Option Option { set; }
        string PhotoUrl { set; }
        decimal Price { set; }
        ProductType ProductType { set; }
        int Rating { set; }
        int Stock { set; }
    }
}