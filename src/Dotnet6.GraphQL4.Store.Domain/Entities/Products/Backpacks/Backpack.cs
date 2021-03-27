using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Backpacks
{
    public class Backpack : Product
    {
        public Backpack(Guid id, string description, DateTimeOffset introduceAt, string name, string photoUrl, decimal price, ProductType productType, int rating, int stock, Option option, BackpackType backpackType)
            : base(id, description, introduceAt, name, photoUrl, price, productType, rating, stock, option)
        {
            BackpackType = backpackType;
            Validate();
        }

        protected Backpack() { }

        public BackpackType BackpackType { get; }

        protected sealed override bool Validate()
            => OnValidate<BackpackValidator, Backpack>(this, new());
    }
}