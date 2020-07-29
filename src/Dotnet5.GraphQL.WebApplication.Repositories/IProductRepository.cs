using System;
using Dotnet5.GraphQL.WebApplication.Domain.Entities.Products;
using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;

namespace Dotnet5.GraphQL.WebApplication.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid> { }
}