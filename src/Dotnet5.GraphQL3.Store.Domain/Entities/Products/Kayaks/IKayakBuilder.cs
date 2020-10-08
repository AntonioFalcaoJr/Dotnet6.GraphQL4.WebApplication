using System;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Kayaks
{
    public interface IKayakBuilder : IProductBuilder<Kayak, Guid>
    {
        IKayakBuilder WithAmountOfPerson(int amountOfPerson);
        IKayakBuilder WithType(KayakType type);
    }
}