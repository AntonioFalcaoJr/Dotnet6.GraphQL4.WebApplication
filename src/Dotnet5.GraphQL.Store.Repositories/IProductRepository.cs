using System;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Repositories.Abstractions;

namespace Dotnet5.GraphQL.Store.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid> { }
}