using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks
{
    public interface IKayakBuilder : IProductBuilder<Kayak, Guid>
    {
        IKayakBuilder WithAmountOfPerson(int amountOfPerson);
        IKayakBuilder WithType(KayakType type);
    }
}