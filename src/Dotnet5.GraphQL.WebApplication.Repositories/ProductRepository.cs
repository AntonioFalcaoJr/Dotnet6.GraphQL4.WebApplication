using System;
using Dotnet5.GraphQL.WebApplication.Domain.Entities.Products;
using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;
using Dotnet5.GraphQL.WebApplication.Repositories.Contexts;

namespace Dotnet5.GraphQL.WebApplication.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(StoreContext dbContext)
            : base(dbContext) { }
    }
}