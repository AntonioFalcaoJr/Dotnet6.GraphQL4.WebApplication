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
        string Description { get; set; }
        DateTimeOffset IntroduceAt { get; set; }
        string Name { get; set; }
        Option Option { get; set; }
        string PhotoUrl { get; set; }
        decimal Price { get; set; }
        ProductType ProductType { get; set; }
        int Rating { get; set; }
        int Stock { get; set; }
    }
}