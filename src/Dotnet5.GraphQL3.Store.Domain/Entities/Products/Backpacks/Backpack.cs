using System;
using Dotnet5.GraphQL.Store.Domain.Enumerations;
using Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes;
using FluentValidation;

namespace Dotnet5.GraphQL.Store.Domain.Entities.Products.Backpacks
{
    public class Backpack : Product
    {
        public Backpack(Guid id, string description, DateTimeOffset introduceAt, string name, string photoUrl, decimal price,
            ProductType productType, int rating, int stock, Option option, BackpackType backpackType)
            : base(id, description, introduceAt, name, photoUrl, price, productType, rating, stock, option)
        {
            BackpackType = backpackType;
            Validate();
        }

        protected Backpack() { }

        public BackpackType BackpackType { get; }

        protected sealed override bool Validate()
            => OnValidate(this, new InlineValidator<Backpack>());
    }
}