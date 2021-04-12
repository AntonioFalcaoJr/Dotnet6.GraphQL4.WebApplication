using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks
{
    public interface IBackpackBuilder : IProductBuilder<BackpackBuilder, Backpack, Guid>
    {
        BackpackType Type { get; set; }
    }
}