using System;

namespace Dotnet5.GraphQL.WebApplication.Domain.ValueObjects.ProductTypes
{
    public abstract class ProductType
    {
        public Guid Id { get; set; }
    }
}