using System;

namespace Dotnet5.GraphQL3.Store.Domain.ValueObjects.ProductTypes
{
    public abstract class ProductType
    {
        public Guid Id { get; init; }
    }
}