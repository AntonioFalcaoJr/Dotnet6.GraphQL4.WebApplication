using System;
using Dotnet6.GraphQL4.Store.Domain.Enumerations;
using Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet6.GraphQL4.Store.Domain.Entities.Products.Boots
{
    public class Boot : Product
    {
        public Boot(Guid id, string description, DateTimeOffset introduceAt, string name, string photoUrl, decimal price, ProductType productType, int rating, int stock, Option option, BootType bootType, int size)
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
            => OnValidate<BootValidator, Boot>(this, new());
    }
}