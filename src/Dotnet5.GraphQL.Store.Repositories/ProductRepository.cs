using System;
using Dotnet5.GraphQL.Store.Domain.Entities.Products;
using Dotnet5.GraphQL.Store.Repositories.Abstractions;
using Dotnet5.GraphQL.Store.Repositories.Contexts;

namespace Dotnet5.GraphQL.Store.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(StoreDbContext dbDbContext)
            : base(dbDbContext) { }
    }
}