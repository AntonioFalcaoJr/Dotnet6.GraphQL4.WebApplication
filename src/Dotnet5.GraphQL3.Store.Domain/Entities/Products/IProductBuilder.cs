using System;
using Dotnet5.GraphQL3.Domain.Abstractions.Builders;
using Dotnet5.GraphQL3.Domain.Abstractions.Entities;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products
{
    public interface IProductBuilder<out TProduct, TId> : IBuilder<TProduct, TId>
        where TProduct : Entity<TId>, IProduct
        where TId : struct
    {
        IProductBuilder<TProduct, TId> WithDescription(string description);
        IProductBuilder<TProduct, TId> WithIntroduceAt(DateTimeOffset introduceAt);
        IProductBuilder<TProduct, TId> WithName(string name);
        IProductBuilder<TProduct, TId> WithOption(Option option);
        IProductBuilder<TProduct, TId> WithPhotoUrl(string photoUrl);
        IProductBuilder<TProduct, TId> WithPrice(decimal price);
        IProductBuilder<TProduct, TId> WithProductType(ProductType productType);
        IProductBuilder<TProduct, TId> WithRating(int rating);
        IProductBuilder<TProduct, TId> WithStock(int stock);
    }
}