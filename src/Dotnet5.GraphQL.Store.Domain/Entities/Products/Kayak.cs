using System;
using Dotnet5.GraphQL.Store.Domain.Enumerations;
using Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL.Store.Domain.Entities.Products
{
    public class Kayak : Product
    {
        public Kayak(Guid id, string description, DateTimeOffset introduceAt, string name, string photoFileName, decimal price,
            ProductType productType, int rating, int stock, Option option, KayakType kayakType, int amountOfPerson)
            : base(id, description, introduceAt, name, photoFileName, price, productType, rating, stock, option)
        {
            KayakType = kayakType;
            AmountOfPerson = amountOfPerson;
        }

        protected Kayak() { }

        public int AmountOfPerson { get; }

        public KayakType KayakType { get; }
    }
}