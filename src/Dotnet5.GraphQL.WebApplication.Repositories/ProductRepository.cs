using System;
using Dotnet5.GraphQL.WebApplication.Domain.Entities;
using Dotnet5.GraphQL.WebApplication.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.GraphQL.WebApplication.Repositories
{
    public class ProductRepository : Repository<Product, Guid>, IProductRepository
    {
        public ProductRepository(DbContext dbContext)
            : base(dbContext) { }
    }
}