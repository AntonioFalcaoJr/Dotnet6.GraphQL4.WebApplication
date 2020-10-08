using System;
using Dotnet5.GraphQL3.Repositories.Abstractions;
using Dotnet5.GraphQL3.Store.Domain.Entities.Products;

namespace Dotnet5.GraphQL3.Store.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid> { }
}