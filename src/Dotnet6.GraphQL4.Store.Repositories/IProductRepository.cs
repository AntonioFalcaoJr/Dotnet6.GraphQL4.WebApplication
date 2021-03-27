using System;
using Dotnet6.GraphQL4.Repositories.Abstractions;
using Dotnet6.GraphQL4.Store.Domain.Entities.Products;

namespace Dotnet6.GraphQL4.Store.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid> { }
}