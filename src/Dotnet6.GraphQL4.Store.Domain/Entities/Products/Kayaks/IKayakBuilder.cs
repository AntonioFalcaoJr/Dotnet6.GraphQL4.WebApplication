using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks
{
    public interface IKayakBuilder : IProductBuilder<KayakBuilder, Kayak, Guid>
    {
        int AmountOfPerson { set; }
        KayakType Type { set; }
    }
}