using System;

namespace Dotnet6.GraphQL4.Store.Domain.ValueObjects.ProductTypes
{
    public abstract class ProductType
    {
        public Guid Id { get; init; }
    }
}