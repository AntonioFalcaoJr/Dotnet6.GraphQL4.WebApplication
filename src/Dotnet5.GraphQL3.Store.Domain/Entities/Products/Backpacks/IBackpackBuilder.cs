using System;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Backpacks
{
    public interface IBackpackBuilder : IProductBuilder<Backpack, Guid>
    {
        IBackpackBuilder WithType(BackpackType type);
    }
}