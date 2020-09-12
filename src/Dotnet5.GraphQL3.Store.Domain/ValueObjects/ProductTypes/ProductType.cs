using System;

namespace Dotnet5.GraphQL.Store.Domain.ValueObjects.ProductTypes
{
    public abstract class ProductType
    {
        public Guid Id { get; set; }
    }
}