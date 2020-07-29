using System;
using Dotnet5.GraphQL.WebApplication.Domain.Enumerations;
using Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes;

namespace Dotnet5.GraphQL.WebApplication.Domain.Entities.Products
{
    public class Boot : Product
    {
        public Boot(Guid id, string description, DateTimeOffset introduceAt, string name, string photoFileName, decimal price,
            ProductType productType, int rating, int stock, Option option, BootType bootType, int size)
            : base(id, description, introduceAt, name, photoFileName, price, productType, rating, stock, option)
        {
            BootType = bootType;
            Size = size;
        }

        protected Boot() { }

        public BootType BootType { get; }
        public int Size { get; }
    }
}