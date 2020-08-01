using System;
using Dotnet5.GraphQL.Store.Domain.Enumerations;
using Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL.Store.Domain.Entities.Products
{
    public class Backpack : Product
    {
        public Backpack(Guid id, string description, DateTimeOffset introduceAt, string name, string photoFileName, decimal price,
            ProductType productType, int rating, int stock, Option option, BackpackType backpackType)
            : base(id, description, introduceAt, name, photoFileName, price, productType, rating, stock, option)
        {
            BackpackType = backpackType;
        }

        protected Backpack() { }

        public BackpackType BackpackType { get; }
    }
}