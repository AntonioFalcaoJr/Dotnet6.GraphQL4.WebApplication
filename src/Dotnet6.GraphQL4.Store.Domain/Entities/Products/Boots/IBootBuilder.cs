using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots
{
    public interface IBootBuilder : IProductBuilder<BootBuilder,Boot, Guid>
    {
        BootType Type { get; set; }
        int Size { get; set; }
    }
}