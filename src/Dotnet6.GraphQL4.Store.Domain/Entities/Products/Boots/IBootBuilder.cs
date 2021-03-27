using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots
{
    public interface IBootBuilder : IProductBuilder<Boot, Guid>
    {
        IBootBuilder WithType(BootType type);
        IBootBuilder WithSize(int size);
    }
}