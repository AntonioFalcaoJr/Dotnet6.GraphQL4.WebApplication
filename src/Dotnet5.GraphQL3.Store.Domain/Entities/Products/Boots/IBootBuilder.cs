using System;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Boots
{
    public interface IBootBuilder : IProductBuilder<Boot, Guid>
    {
        IBootBuilder WithType(BootType type);
        IBootBuilder WithSize(int size);
    }
}