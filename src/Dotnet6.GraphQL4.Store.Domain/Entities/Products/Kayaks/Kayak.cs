using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Kayaks
{
    public class Kayak : Product
    {
        internal Kayak(Guid id, string description, DateTimeOffset introduceAt, string name, string photoUrl, decimal price, ProductType productType, int rating, int stock, Option option, KayakType kayakType, int amountOfPerson)
            : base(id, description, introduceAt, name, photoUrl, price, productType, rating, stock, option)
        {
            KayakType = kayakType;
            AmountOfPerson = amountOfPerson;
            Validate();
        }

        protected Kayak() { }

        public int AmountOfPerson { get; }
        public KayakType KayakType { get; }

        protected sealed override bool Validate()
            => OnValidate<KayakValidator, Kayak>(this, new());
    }
}