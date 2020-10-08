using System;
using Dotnet5.GraphQL3.Store.Domain.Enumerations;
using Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL3.Store.Domain.Entities.Products.Boots
{
    public class Boot : Product
    {
        public Boot(Guid id, string description, DateTimeOffset introduceAt, string name, string photoUrl, decimal price,
            ProductType productType, int rating, int stock, Option option, BootType bootType, int size)
            : base(id, description, introduceAt, name, photoUrl, price, productType, rating, stock, option)
        {
            BootType = bootType;
            Size = size;
            Validate();
        }

        protected Boot() { }

        public BootType BootType { get; }
        public int Size { get; }

        protected sealed override bool Validate()
            => OnValidate(this, new BootValidator());
    }
}